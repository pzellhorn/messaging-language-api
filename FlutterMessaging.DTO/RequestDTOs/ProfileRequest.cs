namespace FlutterMessaging.DTO.RequestDTOs
{
    public class ProfileRequest
    {
        public ProfileRequest() { }
        public ProfileRequest(Guid? profileId, string profileName, string emailAddress)
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


