namespace FlutterMessaging.DTO.RequestDTOs.MessagingRequests
{
    public class ListChatRoomsRequest
    {  
        public int Limit { get; set; } = 20;
        public DateTime? MessagesAfter { get; set; }
    }
}
