namespace FlutterMessaging.DTO.ResponseDTOs
{
    public class LanguageWordFrequencyResponse
    {
        public LanguageWordFrequencyResponse() { }
        public LanguageWordFrequencyResponse(Guid? languageWordFrequencyId, Guid languageId, Guid languageTranslationId, int frequencyRank)
        {
            this.LanguageWordFrequencyId = languageWordFrequencyId;
            this.LanguageId = languageId;
            this.LanguageTranslationId = languageTranslationId;
            this.FrequencyRank = frequencyRank;
        }
        public Guid? LanguageWordFrequencyId { get; }
        public Guid LanguageId { get; }
        public Guid LanguageTranslationId { get; }
        public int FrequencyRank { get; }
    }
}
