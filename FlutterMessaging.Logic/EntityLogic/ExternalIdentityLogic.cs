using FlutterMessaging.DTO.Security;
using FlutterMessaging.Logic.Base;
using FlutterMessaging.Logic.ServiceLogic;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;
using Google.Apis.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace FlutterMessaging.Logic.EntityLogic
{
    public class ExternalIdentityLogic(
      IBaseRepository<ExternalIdentity> externalIdentityRepository,
      IBaseRepository<Profile> profileRepository,
      ITokenIssuer tokenIssuer,
      IOptions<JwtOptions> jwtOptions,
      SigningCredentials signingCredentials
  ) : BaseLogic<ExternalIdentity>(externalIdentityRepository)
    {
        public async Task<string> AuthenticateWithGoogle(string token, string nonce, string deviceId,  CancellationToken cancellationToken)
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


            //Mint token for user authentication
            JwtOptions options = jwtOptions.Value;

            string mintedToken = tokenIssuer.IssueAccessToken(profile.ProfileId, deviceId, options.Audience, TimeSpan.FromMinutes(options.AccessTokenMinutes), signingCredentials);

            return mintedToken; 
        }
    }
}
