using Microsoft.IdentityModel.Tokens;

namespace FlutterMessaging.Logic.ServiceLogic
{
    public interface ITokenIssuer
    {
        public string IssueAccessToken(Guid profileId, string deviceId, string audience, TimeSpan lifetime, SigningCredentials signingCredentials);
    }
}
