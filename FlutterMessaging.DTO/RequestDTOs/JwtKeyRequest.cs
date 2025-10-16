namespace FlutterMessaging.DTO.RequestDTOs
{
    public class JwtKeyRequest
    {
        public JwtKeyRequest() { }
        public JwtKeyRequest(Guid? jwtKeyId, string kid, string alg, string publicKeyPem, bool isActive, string? keyVaultKeyId)
        {
            this.JwtKeyId = jwtKeyId;
            this.Kid = kid;
            this.Alg = alg;
            this.PublicKeyPem = publicKeyPem;
            this.IsActive = isActive;
            this.KeyVaultKeyId = keyVaultKeyId;
        }
        public Guid? JwtKeyId { get; }
        public string Kid { get; }
        public string Alg { get; }
        public string PublicKeyPem { get; }
        public bool IsActive { get; }
        public string? KeyVaultKeyId { get; }
    }
}


