namespace FlutterMessaging.DTO.ResponseDTOs
{
    public class ProfileSettingResponse
    {
        public ProfileSettingResponse() { }
        public ProfileSettingResponse(Guid? profileSettingId, Guid profileId)
        {
            this.ProfileSettingId = profileSettingId;
            this.ProfileId = profileId;
        }
        public Guid? ProfileSettingId { get; }
        public Guid ProfileId { get; }
    }
}
