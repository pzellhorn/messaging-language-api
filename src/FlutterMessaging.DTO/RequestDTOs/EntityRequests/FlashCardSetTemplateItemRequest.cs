namespace FlutterMessaging.DTO.RequestDTOs.EntityDTOs
{
    public class FlashCardSetTemplateItemRequest
    {
        public FlashCardSetTemplateItemRequest() { }
        public FlashCardSetTemplateItemRequest(Guid? flashCardSetTemplateItemId, Guid flashCardSetTemplateId, string question)
        {
            FlashCardSetTemplateItemId = flashCardSetTemplateItemId;
            FlashCardSetTemplateId = flashCardSetTemplateId;
            Question = question;
        }
        public Guid? FlashCardSetTemplateItemId { get; set; }
        public Guid FlashCardSetTemplateId { get; set; }
        public string Question { get; set; }
    }
}


