using System;

namespace FlutterMessaging.DTO.RequestDTOs;

public class ProfileSettingRequest(Guid? profileSettingId, Guid profileId)
{
    public Guid? ProfileSettingId { get; } = profileSettingId;
    public Guid ProfileId { get; } = profileId;
}
