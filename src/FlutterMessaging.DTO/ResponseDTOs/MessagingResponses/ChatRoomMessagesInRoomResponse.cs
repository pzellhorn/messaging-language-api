using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.DTO.Types;

namespace FlutterMessaging.DTO.ResponseDTOs.MessagingResponses
{
    public class ChatRoomMessagesInRoomResponse
    {
        public List<Types.ChatRoomMessageTypeResponse> Items { get; set; } = new();
        public Guid? NextAfterMessageId { get; set; }
        public bool HasMore { get; set; }
    }
}
