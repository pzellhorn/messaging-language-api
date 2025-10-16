namespace FlutterMessaging.DTO.RequestDTOs
{
    public class RefreshTokenRequest
    {
        public RefreshTokenRequest() { }
        public RefreshTokenRequest(Guid? refreshTokenId, Guid sessionId, string tokenHash, string tokenSalt, DateTime expiresAt, DateTime? revokedAt, Guid? replacedById)
        {
            this.RefreshTokenId = refreshTokenId;
            this.SessionId = sessionId;
            this.TokenHash = tokenHash;
            this.TokenSalt = tokenSalt;
            this.ExpiresAt = expiresAt;
            this.RevokedAt = revokedAt;
            this.ReplacedById = replacedById;
        }
        public Guid? RefreshTokenId { get; set; }
        public Guid SessionId { get; set; }
        public string TokenHash { get; set; }
        public string TokenSalt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime? RevokedAt { get; set; }
        public Guid? ReplacedById { get; set; }
    }
}


