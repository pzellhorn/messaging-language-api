namespace FlutterMessaging.DTO.ResponseDTOs.EntityResponses
{
    public class LanguageResponse
    {
        public LanguageResponse() { }
        public LanguageResponse(Guid? languageId, string name)
        {
            LanguageId = languageId;
            Name = name;
        }
        public Guid? LanguageId { get; set; }
        public string Name { get; set; }
    }
}
