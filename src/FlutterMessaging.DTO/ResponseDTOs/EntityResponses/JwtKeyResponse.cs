namespace FlutterMessaging.DTO.ResponseDTOs.EntityResponses
{
    public class JwtKeyResponse
    {
        public JwtKeyResponse() { }
        public JwtKeyResponse(Guid? jwtKeyId, string kid, string alg, string publicKeyPem, bool isActive, string? keyVaultKeyId)
        {
            JwtKeyId = jwtKeyId;
            Kid = kid;
            Alg = alg;
            PublicKeyPem = publicKeyPem;
            IsActive = isActive;
            KeyVaultKeyId = keyVaultKeyId;
        }
        public Guid? JwtKeyId { get; set; }
        public string Kid { get; set; }
        public string Alg { get; set; }
        public string PublicKeyPem { get; set; }
        public bool IsActive { get; set; }
        public string? KeyVaultKeyId { get; set; }
    }
}
