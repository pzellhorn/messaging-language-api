namespace FlutterMessaging.DTO.RequestDTOs;

public class FlashCardSetTemplateItemOptionRequest(Guid? flashCardSetTemplateItemOptionId, Guid flashCardSetTemplateItemId, string optionKey, string optionValue)
{
    public Guid? FlashCardSetTemplateItemOptionId { get; } = flashCardSetTemplateItemOptionId;
    public Guid FlashCardSetTemplateItemId { get; } = flashCardSetTemplateItemId;
    public string OptionKey { get; } = optionKey;
    public string OptionValue { get; } = optionValue;
}
