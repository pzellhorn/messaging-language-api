namespace FlutterMessaging.DTO.ResponseDTOs.EntityResponses
{
    public class ExternalIdentityResponse
    {
        public ExternalIdentityResponse() { }
        public ExternalIdentityResponse(Guid? externalIdentityId, Guid profileId, string provider, string subject, string issuer)
        {
            ExternalIdentityId = externalIdentityId;
            ProfileId = profileId;
            Provider = provider;
            Subject = subject;
            Issuer = issuer;
        }
        public Guid? ExternalIdentityId { get; set; }
        public Guid ProfileId { get; set; }
        public string Provider { get; set; }
        public string Subject { get; set; }
        public string Issuer { get; set; }
    }
}
