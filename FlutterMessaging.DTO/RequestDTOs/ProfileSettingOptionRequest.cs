namespace FlutterMessaging.DTO.RequestDTOs
{
    public class ProfileSettingOptionRequest
    {
        public ProfileSettingOptionRequest() { }
        public ProfileSettingOptionRequest(Guid? profileSettingOptionId, Guid profileSettingId, string optionKey, string optionValue)
        {
            this.ProfileSettingOptionId = profileSettingOptionId;
            this.ProfileSettingId = profileSettingId;
            this.OptionKey = optionKey;
            this.OptionValue = optionValue;
        }
        public Guid? ProfileSettingOptionId { get; }
        public Guid ProfileSettingId { get; }
        public string OptionKey { get; }
        public string OptionValue { get; }
    }
}


