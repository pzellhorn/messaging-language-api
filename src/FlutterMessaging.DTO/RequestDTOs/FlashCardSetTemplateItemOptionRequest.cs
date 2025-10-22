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
        public Guid? FlashCardSetTemplateItemOptionId { get; set; }
        public Guid FlashCardSetTemplateItemId { get; set; }
        public string OptionKey { get; set; }
        public string OptionValue { get; set; }
    }

}


