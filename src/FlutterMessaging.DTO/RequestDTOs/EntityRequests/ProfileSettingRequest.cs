namespace FlutterMessaging.DTO.RequestDTOs.EntityDTOs
{
    public class ProfileSettingRequest
    {
        public ProfileSettingRequest() { }
        public ProfileSettingRequest(Guid? profileSettingId, Guid profileId)
        {
            ProfileSettingId = profileSettingId;
            ProfileId = profileId;
        }
        public Guid? ProfileSettingId { get; set; }
        public Guid ProfileId { get; set; }
    }
}