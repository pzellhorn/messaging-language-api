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
        public Guid? ChatRoomMessageId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid ChatRoomId { get; set; }
        public string MessageText { get; set; }
    }
 
}

