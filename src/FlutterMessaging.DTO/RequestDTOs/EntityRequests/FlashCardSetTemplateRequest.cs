namespace FlutterMessaging.DTO.RequestDTOs.EntityDTOs
{
    public class FlashCardSetTemplateRequest
    {
        public FlashCardSetTemplateRequest() { }
        public FlashCardSetTemplateRequest(Guid? flashCardSetTemplateId, string flashCardSetName, int flashCardType)
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


