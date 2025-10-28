namespace FlutterMessaging.DTO.ResponseDTOs.EntityResponses
{
    public class FlashCardSetTemplateResponse
    {
        public FlashCardSetTemplateResponse() { }
        public FlashCardSetTemplateResponse(Guid? flashCardSetTemplateId, string flashCardSetName, int flashCardType)
        {
            FlashCardSetTemplateId = flashCardSetTemplateId;
            FlashCardSetName = flashCardSetName;
            FlashCardType = flashCardType;
        }
        public Guid? FlashCardSetTemplateId { get; set; }
        public string FlashCardSetName { get; set; }
        public int FlashCardType { get; set; }
    }
}
