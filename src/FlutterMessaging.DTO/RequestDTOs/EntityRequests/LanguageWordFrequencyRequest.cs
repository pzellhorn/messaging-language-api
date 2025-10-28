namespace FlutterMessaging.DTO.RequestDTOs.EntityDTOs
{
    public class LanguageWordFrequencyRequest
    {
        public LanguageWordFrequencyRequest() { }
        public LanguageWordFrequencyRequest(Guid? languageWordFrequencyId, Guid languageId, Guid languageTranslationId, int frequencyRank)
        {
            LanguageWordFrequencyId = languageWordFrequencyId;
            LanguageId = languageId;
            LanguageTranslationId = languageTranslationId;
            FrequencyRank = frequencyRank;
        }
        public Guid? LanguageWordFrequencyId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid LanguageTranslationId { get; set; }
        public int FrequencyRank { get; set; }
    }

}

