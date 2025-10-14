using System;

namespace FlutterMessaging.DTO.RequestDTOs;

public class FlashCardSetTemplateItemRequest(Guid? flashCardSetTemplateItemId, Guid flashCardSetTemplateId, string question)
{
    public Guid? FlashCardSetTemplateItemId { get; } = flashCardSetTemplateItemId;
    public Guid FlashCardSetTemplateId { get; } = flashCardSetTemplateId;
    public string Question { get; } = question;
}
