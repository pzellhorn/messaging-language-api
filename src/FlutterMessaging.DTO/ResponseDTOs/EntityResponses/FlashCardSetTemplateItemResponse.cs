namespace FlutterMessaging.DTO.ResponseDTOs.EntityResponses
{
    public class FlashCardSetTemplateItemResponse
    {
        public FlashCardSetTemplateItemResponse() { }
        public FlashCardSetTemplateItemResponse(Guid? flashCardSetTemplateItemId, Guid flashCardSetTemplateId, string question)
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
