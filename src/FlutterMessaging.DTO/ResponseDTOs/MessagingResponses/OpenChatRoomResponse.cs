using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.DTO.Types;

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
