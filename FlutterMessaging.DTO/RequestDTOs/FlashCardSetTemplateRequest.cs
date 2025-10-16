namespace FlutterMessaging.DTO.RequestDTOs
{
    public class FlashCardSetTemplateRequest
    {
        public FlashCardSetTemplateRequest() { }
        public FlashCardSetTemplateRequest(Guid? flashCardSetTemplateId, string flashCardSetName, int flashCardType)
        {
            this.FlashCardSetTemplateId = flashCardSetTemplateId;
            this.FlashCardSetName = flashCardSetName;
            this.FlashCardType = flashCardType;
        }
        public Guid? FlashCardSetTemplateId { get; }
        public string FlashCardSetName { get; }
        public int FlashCardType { get; }
    }
}


