namespace FlutterMessaging.DTO.ResponseDTOs
{
    public class RefreshTokenResponse
    {
        public RefreshTokenResponse() { }
        public RefreshTokenResponse(Guid? refreshTokenId, Guid sessionId, string tokenHash, string tokenSalt, DateTime expiresAt, DateTime? revokedAt, Guid? replacedById)
        {
            this.RefreshTokenId = refreshTokenId;
            this.SessionId = sessionId;
            this.TokenHash = tokenHash;
            this.TokenSalt = tokenSalt;
            this.ExpiresAt = expiresAt;
            this.RevokedAt = revokedAt;
            this.ReplacedById = replacedById;
        }
        public Guid? RefreshTokenId { get; }
        public Guid SessionId { get; }
        public string TokenHash { get; }
        public string TokenSalt { get; }
        public DateTime ExpiresAt { get; }
        public DateTime? RevokedAt { get; }
        public Guid? ReplacedById { get; }
    }
}
