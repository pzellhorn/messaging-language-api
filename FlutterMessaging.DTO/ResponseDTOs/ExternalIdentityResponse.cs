namespace FlutterMessaging.DTO.ResponseDTOs
{
    public class ExternalIdentityResponse
    {
        public ExternalIdentityResponse() { }
        public ExternalIdentityResponse(Guid? externalIdentityId, Guid profileId, string provider, string subject, string issuer)
        {
            this.ExternalIdentityId = externalIdentityId;
            this.ProfileId = profileId;
            this.Provider = provider;
            this.Subject = subject;
            this.Issuer = issuer;
        }
        public Guid? ExternalIdentityId { get; }
        public Guid ProfileId { get; }
        public string Provider { get; }
        public string Subject { get; }
        public string Issuer { get; }
    }
}
