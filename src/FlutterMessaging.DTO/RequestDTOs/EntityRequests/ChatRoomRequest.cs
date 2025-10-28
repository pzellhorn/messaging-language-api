namespace FlutterMessaging.DTO.RequestDTOs.EntityDTOs
{
    public class ChatRoomRequest
    {
        public ChatRoomRequest() { }
        public ChatRoomRequest(Guid? chatRoomId, string name)
        {
            ChatRoomId = chatRoomId;
            Name = name;
        }
        public Guid? ChatRoomId { get; set; }
        public string Name { get; set; }
    }

}
