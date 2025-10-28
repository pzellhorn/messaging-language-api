using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.DTO.ResponseDTOs.MessagingResponses;

namespace FlutterMessaging.DTO.Types
{ 
    public class ChatRoomItemResponse
    {
        public Guid ChatRoomId { get; set; }
        public MessageParticipantResponse OtherParticipant { get; set; } = default!;
        public MessageParticipantResponse? LastMessage { get; set; }
        public int UnreadCount { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
