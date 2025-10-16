namespace FlutterMessaging.DTO.RequestDTOs;

public class LanguageRequest(Guid? languageId, string name)
{
    public Guid? LanguageId { get; } = languageId;
    public string Name { get; } = name;
}
