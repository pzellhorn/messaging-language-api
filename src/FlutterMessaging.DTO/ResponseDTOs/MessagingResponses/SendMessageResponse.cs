using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.DTO.Types;

namespace FlutterMessaging.DTO.ResponseDTOs.MessagingResponses
{
    public class SendMessageResponse
    {
        public Types.ChatRoomMessageTypeResponse Message { get; set; } 
    }
}
