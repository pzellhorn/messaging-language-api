namespace FlutterMessaging.DTO.RequestDTOs.MessagingRequests
{
    public class LLMTranslationRequest
    {
        public string? MessageContext { get; set; }
        public string MessageToTranslate { get; set; }
        public string FromLanguage { get; set; }
        public string ToLanguage { get; set; }
    }
}
