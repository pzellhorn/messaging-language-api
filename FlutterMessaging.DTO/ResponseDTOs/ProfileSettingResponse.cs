namespace FlutterMessaging.DTO.ResponseDTOs;

public class ProfileSettingResponse(Guid? profileSettingId, Guid profileId)
{
    public Guid? ProfileSettingId { get; } = profileSettingId;
    public Guid ProfileId { get; } = profileId;
}
