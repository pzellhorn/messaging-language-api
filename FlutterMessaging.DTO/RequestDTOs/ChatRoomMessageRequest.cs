namespace FlutterMessaging.DTO.RequestDTOs
{
    public class ChatRoomMessageRequest
    {
        public ChatRoomMessageRequest() { }
        public ChatRoomMessageRequest(Guid? chatRoomMessageId, Guid profileId, Guid chatRoomId, string messageText)
        {
            this.ChatRoomMessageId = chatRoomMessageId;
            this.ProfileId = profileId;
            this.ChatRoomId = chatRoomId;
            this.MessageText = messageText;
        }
        public Guid? ChatRoomMessageId { get; }
        public Guid ProfileId { get; }
        public Guid ChatRoomId { get; }
        public string MessageText { get; }
    }
 
}

