using FlutterMessaging.DTO.Types;

namespace FlutterMessaging.DTO.ResponseDTOs.MessagingResponses
{
    public class ListChatRoomsResponse
    {
        public List<ChatRoomItemResponse> Items { get; set; } = new();
        public DateTime? ReadUpTo { get; set; }
        public bool HasNextPage { get; set; }   
    }
}
