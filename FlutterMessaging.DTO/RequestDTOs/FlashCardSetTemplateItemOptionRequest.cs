namespace FlutterMessaging.DTO.RequestDTOs
{
    public class FlashCardSetTemplateItemOptionRequest
    {
        public FlashCardSetTemplateItemOptionRequest() { }
        public FlashCardSetTemplateItemOptionRequest(Guid? flashCardSetTemplateItemOptionId, Guid flashCardSetTemplateItemId, string optionKey, string optionValue)
        {
            this.FlashCardSetTemplateItemOptionId = flashCardSetTemplateItemOptionId;
            this.FlashCardSetTemplateItemId = flashCardSetTemplateItemId;
            this.OptionKey = optionKey;
            this.OptionValue = optionValue;
        }
        public Guid? FlashCardSetTemplateItemOptionId { get; }
        public Guid FlashCardSetTemplateItemId { get; }
        public string OptionKey { get; }
        public string OptionValue { get; }
    }

}


