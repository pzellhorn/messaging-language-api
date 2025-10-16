namespace FlutterMessaging.DTO.ResponseDTOs
{
    public class FlashCardSetTemplateItemResponse
    {
        public FlashCardSetTemplateItemResponse() { }
        public FlashCardSetTemplateItemResponse(Guid? flashCardSetTemplateItemId, Guid flashCardSetTemplateId, string question)
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
