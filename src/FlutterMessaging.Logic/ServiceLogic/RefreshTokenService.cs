using System.Security.Cryptography;
using System.Text;
using FlutterMessaging.State.Data.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using FlutterMessaging.DTO.Types;

namespace FlutterMessaging.Logic.ServiceLogic
{
    public class RefreshTokenService(IOptions<RefreshTokenOptions> options) : IRefreshTokenService
    { 
        private readonly byte[] _pepperKey = string.IsNullOrEmpty(options.Value?.Pepper) ? [] : Encoding.UTF8.GetBytes(options.Value.Pepper);

        public (string RefreshToken, RefreshToken token) Create(Guid sessionId, DateTimeOffset nowUtc)
        {
            // Generate random token & salt for our refreshToken
            string tokenString = Base64UrlEncoder.Encode(RandomNumberGenerator.GetBytes(Math.Max(16, options.Value.TokenSizeBytes)));
            string salt = Base64UrlEncoder.Encode(RandomNumberGenerator.GetBytes(Math.Max(8, options.Value.SaltSizeBytes)));

            string hash = Hash(tokenString, salt);

            RefreshToken newTokenEntity = new()
            { 
                SessionId = sessionId,
                TokenHash = hash,
                TokenSalt = salt,
                ExpiresAt = nowUtc.AddDays(options.Value.DaysToLive).UtcDateTime,
                RevokedAt = null,
                ReplacedById = null,
                CreatedAt = nowUtc.UtcDateTime,
                ModifiedAt = nowUtc.UtcDateTime,
                IsDeleted = false
            };

            return (tokenString, newTokenEntity);
        }

        public bool Verify(string presentedToken, string salt, string storedHash)
        {
            string computed = Hash(presentedToken, salt);

            byte[] storedBytes = Convert.FromBase64String(storedHash);
            byte[] computedBytes = Convert.FromBase64String(computed);

            return CryptographicOperations.FixedTimeEquals(storedBytes, computedBytes);
        }

        public string Hash(string token, string salt)
        {
            byte[] data = Encoding.UTF8.GetBytes($"{salt}.{token}");

            if (_pepperKey.Length == 0)
            {
                byte[] digest = SHA256.HashData(data);
                return Convert.ToBase64String(digest);
            }
             
            HMACSHA256 hmac = new(_pepperKey);

            byte[] mac = hmac.ComputeHash(data);
            return Convert.ToBase64String(mac);
        } 
    }
}
