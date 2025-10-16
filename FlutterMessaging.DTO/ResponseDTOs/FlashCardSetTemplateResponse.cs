namespace FlutterMessaging.DTO.ResponseDTOs
{
    public class FlashCardSetTemplateResponse
    {
        public FlashCardSetTemplateResponse() { }
        public FlashCardSetTemplateResponse(Guid? flashCardSetTemplateId, string flashCardSetName, int flashCardType)
        {
            this.FlashCardSetTemplateId = flashCardSetTemplateId;
            this.FlashCardSetName = flashCardSetName;
            this.FlashCardType = flashCardType;
        }
        public Guid? FlashCardSetTemplateId { get; set; }
        public string FlashCardSetName { get; set; }
        public int FlashCardType { get; set; }
    }
}
