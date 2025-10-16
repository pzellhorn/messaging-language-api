namespace FlutterMessaging.DTO.ResponseDTOs
{
    public class LanguageResponse
    {
        public LanguageResponse() { }
        public LanguageResponse(Guid? languageId, string name)
        {
            this.LanguageId = languageId;
            this.Name = name;
        }
        public Guid? LanguageId { get; set; }
        public string Name { get; set; }
    }
}
