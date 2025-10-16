namespace FlutterMessaging.DTO.ResponseDTOs;

public class FlashCardSetTemplateResponse(Guid? flashCardSetTemplateId, string flashCardSetName, int flashCardType)
{
    public Guid? FlashCardSetTemplateId { get; } = flashCardSetTemplateId;
    public string FlashCardSetName { get; } = flashCardSetName;
    public int FlashCardType { get; } = flashCardType;
}
