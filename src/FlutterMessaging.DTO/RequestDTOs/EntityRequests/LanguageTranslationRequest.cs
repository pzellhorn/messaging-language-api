namespace FlutterMessaging.DTO.RequestDTOs.EntityDTOs
{
    public class LanguageTranslationRequest
    {
        public LanguageTranslationRequest() { }
        public LanguageTranslationRequest(Guid? languageTranslationId, Guid fromLanguageId, Guid toLanguageId, string fromLanguageText, string toLanguageText)
        {
            LanguageTranslationId = languageTranslationId;
            FromLanguageId = fromLanguageId;
            ToLanguageId = toLanguageId;
            FromLanguageText = fromLanguageText;
            ToLanguageText = toLanguageText;
        }
        public Guid? LanguageTranslationId { get; set; }
        public Guid FromLanguageId { get; set; }
        public Guid ToLanguageId { get; set; }
        public string FromLanguageText { get; set; }
        public string ToLanguageText { get; set; }
    }
}


