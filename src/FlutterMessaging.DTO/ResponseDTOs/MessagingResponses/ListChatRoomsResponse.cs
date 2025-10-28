using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.DTO.Types;

namespace FlutterMessaging.DTO.ResponseDTOs.MessagingResponses
{
    public class ListChatRoomsResponse
    {
        public List<ChatRoomItemResponse> Items { get; set; } = new();
        public DateTime? NextCursorCreatedAtUtc { get; set; }
    }
}
