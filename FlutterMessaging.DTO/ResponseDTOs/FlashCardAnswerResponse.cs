using System;

namespace FlutterMessaging.DTO.ResponseDTOs;

public class FlashCardAnswerResponse(Guid? flashCardAnswerId, Guid flashCardSetTemplateItemId, Guid profileId, string answer)
{
    public Guid? FlashCardAnswerId { get; } = flashCardAnswerId;
    public Guid FlashCardSetTemplateItemId { get; } = flashCardSetTemplateItemId;
    public Guid ProfileId { get; } = profileId;
    public string Answer { get; } = answer;
}
