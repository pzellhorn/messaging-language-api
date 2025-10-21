namespace FlutterMessaging.DTO.Types
{
    public class ConversationMessage
    {
        public Guid ConversationMessageId { get; set; }
        public Guid ConversationId { get; set; }
        public Guid AuthorId { get; set; }
        public string Text { get; set; }
    }
}
