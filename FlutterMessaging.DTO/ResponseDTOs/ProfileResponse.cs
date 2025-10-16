namespace FlutterMessaging.DTO.ResponseDTOs;

public class ProfileResponse(Guid? profileId, string profileName, string emailAddress)
{
    public Guid? ProfileId { get; } = profileId;
    public string ProfileName { get; } = profileName;
    public string EmailAddress { get; } = emailAddress;
}
