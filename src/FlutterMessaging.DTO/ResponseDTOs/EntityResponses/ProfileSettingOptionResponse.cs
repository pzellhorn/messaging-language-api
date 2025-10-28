namespace FlutterMessaging.DTO.ResponseDTOs.EntityResponses
{
    public class ProfileSettingOptionResponse
    {
        public ProfileSettingOptionResponse() { }
        public ProfileSettingOptionResponse(Guid? profileSettingOptionId, Guid profileSettingId, string optionKey, string optionValue)
        {
            ProfileSettingOptionId = profileSettingOptionId;
            ProfileSettingId = profileSettingId;
            OptionKey = optionKey;
            OptionValue = optionValue;
        }
        public Guid? ProfileSettingOptionId { get; set; }
        public Guid ProfileSettingId { get; set; }
        public string OptionKey { get; set; }
        public string OptionValue { get; set; }
    }
}
