namespace FlutterMessaging.DTO.RequestDTOs.EntityDTOs
{
    public class FlashCardAnswerRequest
    {
        public FlashCardAnswerRequest() { }
        public FlashCardAnswerRequest(Guid? flashCardAnswerId, Guid flashCardSetTemplateItemId, Guid profileId, string answer)
        {
            FlashCardAnswerId = flashCardAnswerId;
            FlashCardSetTemplateItemId = flashCardSetTemplateItemId;
            ProfileId = profileId;
            Answer = answer;
        }
        public Guid? FlashCardAnswerId { get; set; }
        public Guid FlashCardSetTemplateItemId { get; set; }
        public Guid ProfileId { get; set; }
        public string Answer { get; set; }
    }
}


