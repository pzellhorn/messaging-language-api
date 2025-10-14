using System;

namespace FlutterMessaging.DTO.RequestDTOs;

public class ProfileSettingOptionRequest(Guid? profileSettingOptionId, Guid profileSettingId, string optionKey, string optionValue)
{
    public Guid? ProfileSettingOptionId { get; } = profileSettingOptionId;
    public Guid ProfileSettingId { get; } = profileSettingId;
    public string OptionKey { get; } = optionKey;
    public string OptionValue { get; } = optionValue;
}
