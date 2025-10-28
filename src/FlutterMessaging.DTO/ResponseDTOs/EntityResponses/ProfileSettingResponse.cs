namespace FlutterMessaging.DTO.ResponseDTOs.EntityResponses
{
    public class ProfileSettingResponse
    {
        public ProfileSettingResponse() { }
        public ProfileSettingResponse(Guid? profileSettingId, Guid profileId)
        {
            ProfileSettingId = profileSettingId;
            ProfileId = profileId;
        }
        public Guid? ProfileSettingId { get; set; }
        public Guid ProfileId { get; set; }
    }
}
