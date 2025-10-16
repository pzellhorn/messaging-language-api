namespace FlutterMessaging.DTO.ResponseDTOs
{
    public class ChatRoomResponse
    {
        public ChatRoomResponse() { }
        public ChatRoomResponse(Guid? chatRoomId, string name)
        {
            this.ChatRoomId = chatRoomId;
            this.Name = name;
        }
        public Guid? ChatRoomId { get; set; }
        public string Name { get; set; }
    }
}
