namespace FlutterMessaging.DTO.ResponseDTOs.EntityResponses
{
    public class FlashCardSetTemplateItemOptionResponse
    {
        public FlashCardSetTemplateItemOptionResponse() { }
        public FlashCardSetTemplateItemOptionResponse(Guid? flashCardSetTemplateItemOptionId, Guid flashCardSetTemplateItemId, string optionKey, string optionValue)
        {
            FlashCardSetTemplateItemOptionId = flashCardSetTemplateItemOptionId;
            FlashCardSetTemplateItemId = flashCardSetTemplateItemId;
            OptionKey = optionKey;
            OptionValue = optionValue;
        }
        public Guid? FlashCardSetTemplateItemOptionId { get; set; }
        public Guid FlashCardSetTemplateItemId { get; set; }
        public string OptionKey { get; set; }
        public string OptionValue { get; set; }
    }
}
