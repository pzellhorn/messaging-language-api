namespace FlutterMessaging.DTO.ResponseDTOs.EntityResponses
{
    public class ChatRoomMessageResponse
    {
        public ChatRoomMessageResponse() { }
        public ChatRoomMessageResponse(Guid? chatRoomMessageId, Guid profileId, Guid chatRoomId, string messageText, DateTime createdAt)
        {
            ChatRoomMessageId = chatRoomMessageId;
            ProfileId = profileId;
            ChatRoomId = chatRoomId;
            MessageText = messageText;
            CreatedAt = createdAt;
        }
        public Guid? ChatRoomMessageId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid ChatRoomId { get; set; }
        public string MessageText { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
