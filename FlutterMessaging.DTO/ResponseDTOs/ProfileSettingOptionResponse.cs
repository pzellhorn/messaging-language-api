using System;

namespace FlutterMessaging.DTO.ResponseDTOs;

public class ProfileSettingOptionResponse(Guid? profileSettingOptionId, Guid profileSettingId, string optionKey, string optionValue)
{
    public Guid? ProfileSettingOptionId { get; } = profileSettingOptionId;
    public Guid ProfileSettingId { get; } = profileSettingId;
    public string OptionKey { get; } = optionKey;
    public string OptionValue { get; } = optionValue;
}
