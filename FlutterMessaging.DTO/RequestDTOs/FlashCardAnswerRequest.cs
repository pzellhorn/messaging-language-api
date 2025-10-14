using System;

namespace FlutterMessaging.DTO.RequestDTOs;

public class FlashCardAnswerRequest(Guid? flashCardAnswerId, Guid flashCardSetTemplateItemId, Guid profileId, string answer)
{
    public Guid? FlashCardAnswerId { get; } = flashCardAnswerId;
    public Guid FlashCardSetTemplateItemId { get; } = flashCardSetTemplateItemId;
    public Guid ProfileId { get; } = profileId;
    public string Answer { get; } = answer;
}
