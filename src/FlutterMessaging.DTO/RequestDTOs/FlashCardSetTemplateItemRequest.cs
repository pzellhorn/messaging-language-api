namespace FlutterMessaging.DTO.RequestDTOs
{
    public class FlashCardSetTemplateItemRequest
    {
        public FlashCardSetTemplateItemRequest() { }
        public FlashCardSetTemplateItemRequest(Guid? flashCardSetTemplateItemId, Guid flashCardSetTemplateId, string question)
        {
            this.FlashCardSetTemplateItemId = flashCardSetTemplateItemId;
            this.FlashCardSetTemplateId = flashCardSetTemplateId;
            this.Question = question;
        }
        public Guid? FlashCardSetTemplateItemId { get; set; }
        public Guid FlashCardSetTemplateId { get; set; }
        public string Question { get; set; }
    }
}


