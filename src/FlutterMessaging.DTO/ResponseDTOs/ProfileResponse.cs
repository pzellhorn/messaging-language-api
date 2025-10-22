namespace FlutterMessaging.DTO.ResponseDTOs
{
    public class ProfileResponse
    {
        public ProfileResponse() { }
        public ProfileResponse(Guid? profileId, string profileName, string emailAddress)
        {
            this.ProfileId = profileId;
            this.ProfileName = profileName;
            this.EmailAddress = emailAddress;
        }
        public Guid? ProfileId { get; set; }
        public string ProfileName { get; set; }
        public string EmailAddress { get; set; }
    }
}
