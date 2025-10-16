namespace FlutterMessaging.DTO.RequestDTOs
{
    public class FlashCardAnswerRequest
    {
        public FlashCardAnswerRequest() { }
        public FlashCardAnswerRequest(Guid? flashCardAnswerId, Guid flashCardSetTemplateItemId, Guid profileId, string answer)
        {
            this.FlashCardAnswerId = flashCardAnswerId;
            this.FlashCardSetTemplateItemId = flashCardSetTemplateItemId;
            this.ProfileId = profileId;
            this.Answer = answer;
        }
        public Guid? FlashCardAnswerId { get; set; }
        public Guid FlashCardSetTemplateItemId { get; set; }
        public Guid ProfileId { get; set; }
        public string Answer { get; set; }
    }
}


