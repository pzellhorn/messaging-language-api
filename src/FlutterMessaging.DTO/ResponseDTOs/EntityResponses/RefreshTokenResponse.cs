namespace FlutterMessaging.DTO.ResponseDTOs.EntityResponses
{
    public class RefreshTokenResponse
    {
        public RefreshTokenResponse() { }
        public RefreshTokenResponse(Guid? refreshTokenId, Guid sessionId, string tokenHash, string tokenSalt, DateTime expiresAt, DateTime? revokedAt, Guid? replacedById)
        {
            RefreshTokenId = refreshTokenId;
            SessionId = sessionId;
            TokenHash = tokenHash;
            TokenSalt = tokenSalt;
            ExpiresAt = expiresAt;
            RevokedAt = revokedAt;
            ReplacedById = replacedById;
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
