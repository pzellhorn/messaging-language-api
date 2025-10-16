namespace FlutterMessaging.DTO.RequestDTOs
{
    public class ChatRoomRequest
    {
        public ChatRoomRequest() { }
        public ChatRoomRequest(Guid? chatRoomId, string name)
        {
            this.ChatRoomId = chatRoomId;
            this.Name = name;
        }
        public Guid? ChatRoomId { get; }
        public string Name { get; }
    }

} 
