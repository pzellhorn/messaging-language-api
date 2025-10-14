using System;

namespace FlutterMessaging.DTO.ResponseDTOs;

public class RefreshTokenResponse(Guid? refreshTokenId, Guid sessionId, string tokenHash, string tokenSalt, DateTime expiresAt, DateTime? revokedAt, Guid? replacedById)
{
    public Guid? RefreshTokenId { get; } = refreshTokenId;
    public Guid SessionId { get; } = sessionId;
    public string TokenHash { get; } = tokenHash;
    public string TokenSalt { get; } = tokenSalt;
    public DateTime ExpiresAt { get; } = expiresAt;
    public DateTime? RevokedAt { get; } = revokedAt;
    public Guid? ReplacedById { get; } = replacedById;
}
