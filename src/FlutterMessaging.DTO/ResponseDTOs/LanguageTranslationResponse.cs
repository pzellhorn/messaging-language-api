namespace FlutterMessaging.DTO.ResponseDTOs
{
    public class LanguageTranslationResponse
    {
        public LanguageTranslationResponse() { }
        public LanguageTranslationResponse(Guid? languageTranslationId, Guid fromLanguageId, Guid toLanguageId, string fromLanguageText, string toLanguageText)
        {
            this.LanguageTranslationId = languageTranslationId;
            this.FromLanguageId = fromLanguageId;
            this.ToLanguageId = toLanguageId;
            this.FromLanguageText = fromLanguageText;
            this.ToLanguageText = toLanguageText;
        }
        public Guid? LanguageTranslationId { get; set; }
        public Guid FromLanguageId { get; set; }
        public Guid ToLanguageId { get; set; }
        public string FromLanguageText { get; set; }
        public string ToLanguageText { get; set; }
    }
}
