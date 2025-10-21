using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FlutterMessaging.DTO.Types;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FlutterMessaging.Logic.ServiceLogic
{
    public class JwtTokenIssuer(IOptions<JwtOptions> jwtOptions) : ITokenIssuer
    { 
        public string IssueAccessToken(
            Guid profileId,
            string deviceId,
            string audience,
            TimeSpan lifetime,
            SigningCredentials signingCredentials)
        { 

            List<Claim> claims = new();
            claims.Add(new(JwtRegisteredClaimNames.Sub, profileId.ToString()));
            claims.Add(new("pid", profileId.ToString()));
            claims.Add(new("did", deviceId));
            claims.Add(new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
             
            DateTimeOffset now = DateTimeOffset.UtcNow;
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: jwtOptions.Value.Issuer,
                audience: audience,
                claims: claims,
                notBefore: now.UtcDateTime,
                expires: now.Add(lifetime).UtcDateTime,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        } 
    }
}
