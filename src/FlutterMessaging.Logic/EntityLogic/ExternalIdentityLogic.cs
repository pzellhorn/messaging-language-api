    using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.DTO.Types;
using pzellhorn.Core.Logic.Base;
using FlutterMessaging.Logic.ServiceLogic;
using pzellhorn.Core.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;
using Google.Apis.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace FlutterMessaging.Logic.EntityLogic
{
    public class ExternalIdentityLogic(
     IBaseRepository<ExternalIdentity> externalIdentityRepository,
     IBaseRepository<Profile> profileRepository,
     IBaseRepository<Session> sessionRepository,
     IBaseRepository<RefreshToken> refreshTokenRepository,
     ITokenIssuer tokenIssuer,
     IOptions<JwtOptions> jwtOptions,
     SigningCredentials signingCredentials,
     IRefreshTokenService refreshTokenService
 ) : BaseLogic<ExternalIdentity>(externalIdentityRepository)
    {
        public async Task<AuthTokenResponse> AuthenticateWithGoogle(string token, string nonce, string deviceId,  CancellationToken cancellationToken)
        { 
            GoogleJsonWebSignature.ValidationSettings settings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { "535701860749-k1dkt8jpjtek3t9td9kkvpcqohaomeun.apps.googleusercontent.com" }
            };

            GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(token, settings);

            bool validIssuer = payload.Issuer == "https://accounts.google.com" || payload.Issuer == "accounts.google.com";

            if (!validIssuer) throw new UnauthorizedAccessException("Bad issuer");
            if (!payload.EmailVerified) throw new UnauthorizedAccessException("Unverified email");

            ////nonce
            //if (!string.IsNullOrEmpty(nonce) && !string.Equals(payload.Nonce, nonce, StringComparison.Ordinal))
            //    throw new UnauthorizedAccessException("Nonce mismatch");

            string subject = payload.Subject;
            string issuer = payload.Issuer;
            string email = payload.Email;

            List<ExternalIdentity> subjects = await externalIdentityRepository.GetFor(subject, x => x.Subject, cancellationToken);
            Profile? profile = subjects.FirstOrDefault(x => x.Issuer == issuer)?.Profile;

            //If profile does not exist at all, create a new profile
            if (profile == null)
            {
                Profile newProfile = new();
                newProfile.EmailAddress = email;


                profile = await profileRepository.Upsert(newProfile, cancellationToken);
            }

            // If this authentication method is not yet mapped to the user acccount, map a new ExternalIdentity to it. 
            if (!profile.ExternalIdentities.Where(x => x.Issuer == issuer).Any())
            {
                ExternalIdentity newIdentity = new();
                newIdentity.ProfileId = profile.ProfileId;
                newIdentity.Issuer = issuer;
                newIdentity.Provider = "Google";
                newIdentity.Subject = subject;

                await externalIdentityRepository.Upsert(newIdentity, cancellationToken);
            }

            //generate our access token & refresh token
            DateTimeOffset now = DateTimeOffset.UtcNow;
            Session session = new()
            {
                SessionId = Guid.NewGuid(),
                ProfileId = profile.ProfileId,
                DeviceId = deviceId,
                CreatedAt = now.UtcDateTime,
                LastSeenAt = now.UtcDateTime,
                RevokedAt = null,
                IsDeleted = false
            };

            session = await sessionRepository.Upsert(session, cancellationToken);
             
            (string refreshToken, RefreshToken refreshEntity) = refreshTokenService.Create(session.SessionId, now);
            await refreshTokenRepository.Upsert(refreshEntity, cancellationToken);

            string accessToken = tokenIssuer.IssueAccessToken(profile.ProfileId, deviceId, jwtOptions.Value.Audience, TimeSpan.FromMinutes(jwtOptions.Value.AccessTokenMinutes), signingCredentials);
             
            AuthTokenResponse authToken = new()
            {
                AccessToken = accessToken,
                AccessTokenExpiresAt = now.AddMinutes(jwtOptions.Value.AccessTokenMinutes).UtcDateTime,
                RefreshToken = refreshToken, 
                RefreshTokenExpiresAt = refreshEntity.ExpiresAt,
                SessionId = session.SessionId
            };

            return authToken; 
        }

        public async Task<AuthTokenResponse> RotateRefreshToken(Guid sessionId, string refreshToken, CancellationToken cancellationToken)
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;

            List<Session> sessions = await sessionRepository.GetFor(sessionId, x => x.SessionId, cancellationToken);
            Session? session = sessions.FirstOrDefault();
            
            if (session == null || session.RevokedAt != null)
                throw new UnauthorizedAccessException("Invalid session.");

            List<RefreshToken> tokens = await refreshTokenRepository.GetFor(sessionId, x => x.SessionId, cancellationToken);
            if (tokens.Count == 0)
                throw new UnauthorizedAccessException("No refresh token found for session.");
             
            RefreshToken? matchingRefreshToken = null;
            foreach (RefreshToken token in tokens)
            {
                if (refreshTokenService.Verify(refreshToken, token.TokenSalt, token.TokenHash))
                {
                    matchingRefreshToken = token;
                    break;
                }
            }

            if (matchingRefreshToken == null)
                throw new UnauthorizedAccessException("Invalid refresh token.");

            if (matchingRefreshToken.ExpiresAt <= now.UtcDateTime)
                throw new UnauthorizedAccessException("Refresh token expired.");

            if (matchingRefreshToken.RevokedAt != null)
            {
                //We've revoked this refresh token, now revoke the session and tokens within that session
                session.RevokedAt = now.UtcDateTime;
                await sessionRepository.Upsert(session, cancellationToken);

                foreach (RefreshToken token in tokens.Where(x => x.RevokedAt == null))
                {
                    token.RevokedAt = now.UtcDateTime;
                    token.ModifiedAt = now.UtcDateTime;
                    await refreshTokenRepository.Upsert(token, cancellationToken);
                }

                throw new UnauthorizedAccessException("Refresh token revoked.");
            }

            //Make a new refresh token and revoke the old one
            (string newTokenString, RefreshToken newToken) = refreshTokenService.Create(session.SessionId, now); 
             
            newToken = await refreshTokenRepository.Upsert(newToken, cancellationToken);

            matchingRefreshToken.RevokedAt = now.UtcDateTime;
            matchingRefreshToken.ReplacedById = newToken.RefreshTokenId;
            matchingRefreshToken.ModifiedAt = now.UtcDateTime;
            await refreshTokenRepository.Upsert(matchingRefreshToken, cancellationToken);

            string accessToken = tokenIssuer.IssueAccessToken(
                profileId: session.ProfileId,
                deviceId: session.DeviceId, 
                audience: jwtOptions.Value.Audience,
                lifetime: TimeSpan.FromMinutes(jwtOptions.Value.AccessTokenMinutes),
                signingCredentials: signingCredentials
            );
             
            session.LastSeenAt = now.UtcDateTime;
            await sessionRepository.Upsert(session, cancellationToken);

            return new AuthTokenResponse
            {
                AccessToken = accessToken,
                AccessTokenExpiresAt = now.AddMinutes(jwtOptions.Value.AccessTokenMinutes).UtcDateTime,
                RefreshToken = newTokenString,
                RefreshTokenExpiresAt = newToken.ExpiresAt,
                SessionId = session.SessionId
            };
        }
    }
}
