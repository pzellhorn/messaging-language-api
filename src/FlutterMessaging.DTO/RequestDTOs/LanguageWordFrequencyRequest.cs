namespace FlutterMessaging.DTO.RequestDTOs
{
    public class LanguageWordFrequencyRequest
    {
        public LanguageWordFrequencyRequest() { }
        public LanguageWordFrequencyRequest(Guid? languageWordFrequencyId, Guid languageId, Guid languageTranslationId, int frequencyRank)
        {
            this.LanguageWordFrequencyId = languageWordFrequencyId;
            this.LanguageId = languageId;
            this.LanguageTranslationId = languageTranslationId;
            this.FrequencyRank = frequencyRank;
        }
        public Guid? LanguageWordFrequencyId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid LanguageTranslationId { get; set; }
        public int FrequencyRank { get; set; }
    }

}

