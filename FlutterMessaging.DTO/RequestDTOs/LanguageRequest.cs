namespace FlutterMessaging.DTO.RequestDTOs
{
    public class LanguageRequest
    {
        public LanguageRequest() { }
        public LanguageRequest(Guid? languageId, string name)
        {
            this.LanguageId = languageId;
            this.Name = name;
        }
        public Guid? LanguageId { get; }
        public string Name { get; }
    }
}


