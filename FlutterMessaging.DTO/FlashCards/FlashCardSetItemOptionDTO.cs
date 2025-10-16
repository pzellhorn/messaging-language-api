namespace FlutterMessaging.DTO.FlashCards
{
    public class FlashCardSetItemOptionDTO
    {
        public Guid FlashCardSetTemplateItemOptionId { get; set; } 
        public Guid FlashCardSetTemplateItemId { get; set; } 
        public string OptionKey { get; set; } = string.Empty; 
        public string OptionValue { get; set; } = string.Empty;

    }
}
