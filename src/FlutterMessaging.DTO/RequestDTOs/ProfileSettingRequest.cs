namespace FlutterMessaging.DTO.RequestDTOs
{
    public class ProfileSettingRequest
    {
        public ProfileSettingRequest() { }
        public ProfileSettingRequest(Guid? profileSettingId, Guid profileId)
        {
            this.ProfileSettingId = profileSettingId;
            this.ProfileId = profileId;
        }
        public Guid? ProfileSettingId { get; set; }
        public Guid ProfileId { get; set; }
    }
} 