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
        public Guid? ExternalIdentityId { get; set; }
        public Guid ProfileId { get; set; }
        public string Provider { get; set; }
        public string Subject { get; set; }
        public string Issuer { get; set; }
    }
}
