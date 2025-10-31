using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.DTO.ResponseDTOs.MessagingResponses
{
    public class PostChatRoomsDmStartResponse
    {
        public Guid ChatRoomId { get; set; }
        public MessageParticipantResponse OtherParticipant { get; set; } = default!;
        public ChatRoomMessageResponse? LastMessage { get; set; }
        public int UnreadCount { get; set; }
    }

}
