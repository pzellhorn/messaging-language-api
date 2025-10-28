namespace FlutterMessaging.DTO.RequestDTOs.EntityDTOs
{
    public class LanguageRequest
    {
        public LanguageRequest() { }
        public LanguageRequest(Guid? languageId, string name)
        {
            LanguageId = languageId;
            Name = name;
        }
        public Guid? LanguageId { get; set; }
        public string Name { get; set; }
    }
}


