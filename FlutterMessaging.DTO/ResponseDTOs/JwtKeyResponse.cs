namespace FlutterMessaging.DTO.ResponseDTOs
{
    public class JwtKeyResponse
    {
        public JwtKeyResponse() { }
        public JwtKeyResponse(Guid? jwtKeyId, string kid, string alg, string publicKeyPem, bool isActive, string? keyVaultKeyId)
        {
            this.JwtKeyId = jwtKeyId;
            this.Kid = kid;
            this.Alg = alg;
            this.PublicKeyPem = publicKeyPem;
            this.IsActive = isActive;
            this.KeyVaultKeyId = keyVaultKeyId;
        }
        public Guid? JwtKeyId { get; set; }
        public string Kid { get; set; }
        public string Alg { get; set; }
        public string PublicKeyPem { get; set; }
        public bool IsActive { get; set; }
        public string? KeyVaultKeyId { get; set; }
    }
}
