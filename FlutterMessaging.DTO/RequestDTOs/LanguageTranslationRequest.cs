namespace FlutterMessaging.DTO.RequestDTOs
{
    public class LanguageTranslationRequest
    {
        public LanguageTranslationRequest() { }
        public LanguageTranslationRequest(Guid? languageTranslationId, Guid fromLanguageId, Guid toLanguageId, string fromLanguageText, string toLanguageText)
        {
            this.LanguageTranslationId = languageTranslationId;
            this.FromLanguageId = fromLanguageId;
            this.ToLanguageId = toLanguageId;
            this.FromLanguageText = fromLanguageText;
            this.ToLanguageText = toLanguageText;
        }
        public Guid? LanguageTranslationId { get; }
        public Guid FromLanguageId { get; }
        public Guid ToLanguageId { get; }
        public string FromLanguageText { get; }
        public string ToLanguageText { get; }
    }
}


