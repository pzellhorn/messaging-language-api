namespace FlutterMessaging.DTO.ResponseDTOs.MessagingResponses
{
    public class ChatRoomMessagesInRoomResponse
    {
        public List<Types.ChatRoomMessageTypeResponse> Items { get; set; } = new();
        public Guid? NextAfterMessageId { get; set; }
        public bool HasMore { get; set; }
    }
}
