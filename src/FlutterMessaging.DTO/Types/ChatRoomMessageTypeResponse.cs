namespace FlutterMessaging.DTO.Types
{
    public class ChatRoomMessageTypeResponse
    {
        public Guid ChatRoomMessageId { get; set; }
        public Guid ChatRoomId { get; set; }
        public Guid SenderProfileId { get; set; }
        public string MessageText { get; set; } 
        public DateTime CreatedAt { get; set; } 
    }
}
