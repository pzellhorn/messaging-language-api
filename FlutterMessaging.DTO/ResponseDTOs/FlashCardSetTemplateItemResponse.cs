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
        public Guid? FlashCardSetTemplateItemId { get; }
        public Guid FlashCardSetTemplateId { get; }
        public string Question { get; }
    }
}
