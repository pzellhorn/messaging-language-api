using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.ServiceLogic
{
    public interface IRefreshTokenService
    {
        public (string RefreshToken, RefreshToken token) Create(Guid sessionId, DateTimeOffset nowUtc);
         
        public bool Verify(string presentedToken, string salt, string storedHash);
         
        public string Hash(string token, string salt);
    }
}
