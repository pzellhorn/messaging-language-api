namespace FlutterMessaging.DTO.RequestDTOs.EntityDTOs
{
    public class FlashCardSetTemplateItemOptionRequest
    {
        public FlashCardSetTemplateItemOptionRequest() { }
        public FlashCardSetTemplateItemOptionRequest(Guid? flashCardSetTemplateItemOptionId, Guid flashCardSetTemplateItemId, string optionKey, string optionValue)
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


