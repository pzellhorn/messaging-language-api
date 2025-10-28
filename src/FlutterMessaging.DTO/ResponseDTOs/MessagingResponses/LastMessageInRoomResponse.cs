using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterMessaging.DTO.ResponseDTOs.MessagingResponses
{
    public class LastMessageInRoomResponse
    {
        public Guid MessageId { get; set; }
        public string Text { get; set; }  
        public DateTime CreatedAtUtc { get; set; }
        public Guid SenderProfileId { get; set; }
    }
}
