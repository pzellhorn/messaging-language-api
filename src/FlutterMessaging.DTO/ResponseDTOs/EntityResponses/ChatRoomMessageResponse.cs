namespace FlutterMessaging.DTO.ResponseDTOs.EntityResponses
{
    public class ChatRoomMessageResponse
    {
        public ChatRoomMessageResponse() { }
        public ChatRoomMessageResponse(Guid? chatRoomMessageId, Guid profileId, Guid chatRoomId, string messageText)
        {
            ChatRoomMessageId = chatRoomMessageId;
            ProfileId = profileId;
            ChatRoomId = chatRoomId;
            MessageText = messageText;
        }
        public Guid? ChatRoomMessageId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid ChatRoomId { get; set; }
        public string MessageText { get; set; }
    }
}
