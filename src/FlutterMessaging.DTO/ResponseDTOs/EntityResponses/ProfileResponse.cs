namespace FlutterMessaging.DTO.ResponseDTOs.EntityResponses
{
    public class ProfileResponse
    {
        public ProfileResponse() { }
        public ProfileResponse(Guid? profileId, string profileName, string emailAddress)
        {
            ProfileId = profileId;
            ProfileName = profileName;
            EmailAddress = emailAddress;
        }
        public Guid? ProfileId { get; set; }
        public string ProfileName { get; set; }
        public string EmailAddress { get; set; }
    }
}
