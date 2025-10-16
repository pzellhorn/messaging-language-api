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
        public Guid? ProfileId { get; }
        public string ProfileName { get; }
        public string EmailAddress { get; }
    }
}
