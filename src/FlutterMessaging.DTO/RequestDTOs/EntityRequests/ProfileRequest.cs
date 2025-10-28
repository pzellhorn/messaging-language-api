namespace FlutterMessaging.DTO.RequestDTOs.EntityDTOs
{
    public class ProfileRequest
    {
        public ProfileRequest() { }
        public ProfileRequest(Guid? profileId, string profileName, string emailAddress)
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


