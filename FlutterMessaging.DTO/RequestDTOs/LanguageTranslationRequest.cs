namespace FlutterMessaging.DTO.RequestDTOs;

public class LanguageTranslationRequest(Guid? languageTranslationId, Guid fromLanguageId, Guid toLanguageId, string fromLanguageText, string toLanguageText)
{
    public Guid? LanguageTranslationId { get; } = languageTranslationId;
    public Guid FromLanguageId { get; } = fromLanguageId;
    public Guid ToLanguageId { get; } = toLanguageId;
    public string FromLanguageText { get; } = fromLanguageText;
    public string ToLanguageText { get; } = toLanguageText;
}
