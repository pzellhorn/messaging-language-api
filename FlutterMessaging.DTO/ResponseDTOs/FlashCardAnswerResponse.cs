namespace FlutterMessaging.DTO.ResponseDTOs
{
    public class FlashCardAnswerResponse
    {
        public FlashCardAnswerResponse() { }
        public FlashCardAnswerResponse(Guid? flashCardAnswerId, Guid flashCardSetTemplateItemId, Guid profileId, string answer)
        {
            this.FlashCardAnswerId = flashCardAnswerId;
            this.FlashCardSetTemplateItemId = flashCardSetTemplateItemId;
            this.ProfileId = profileId;
            this.Answer = answer;
        }
        public Guid? FlashCardAnswerId { get; }
        public Guid FlashCardSetTemplateItemId { get; }
        public Guid ProfileId { get; }
        public string Answer { get; }
    }
}
