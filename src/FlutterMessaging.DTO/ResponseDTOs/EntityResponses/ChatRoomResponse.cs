namespace FlutterMessaging.DTO.ResponseDTOs.EntityResponses
{
    public class ChatRoomResponse
    {
        public ChatRoomResponse() { }
        public ChatRoomResponse(Guid? chatRoomId, string name)
        {
            ChatRoomId = chatRoomId;
            Name = name;
        }
        public Guid? ChatRoomId { get; set; }
        public string Name { get; set; }
    }
}
