namespace FlutterMessaging.DTO.RequestDTOs
{
    public class ExternalIdentityRequest
    {
        public ExternalIdentityRequest() { }
        public ExternalIdentityRequest(Guid? externalIdentityId, Guid profileId, string provider, string subject, string issuer)
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

