namespace FlutterMessaging.DTO.ResponseDTOs;

public class JwtKeyResponse(Guid? jwtKeyId, string kid, string alg, string publicKeyPem, bool isActive, string? keyVaultKeyId)
{
    public Guid? JwtKeyId { get; } = jwtKeyId;
    public string Kid { get; } = kid;
    public string Alg { get; } = alg;
    public string PublicKeyPem { get; } = publicKeyPem;
    public bool IsActive { get; } = isActive;
    public string? KeyVaultKeyId { get; } = keyVaultKeyId;
}
