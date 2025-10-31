namespace FlutterMessaging.DTO.RequestDTOs.MessagingRequests
{
    public class ChatRoomMessagesInRoomRequest
    {
        public Guid? AfterMessageId { get; set; }
        public DateTime MessagesAfter { get; set; }
        public int Limit { get; set; } = 50;
    }
}
