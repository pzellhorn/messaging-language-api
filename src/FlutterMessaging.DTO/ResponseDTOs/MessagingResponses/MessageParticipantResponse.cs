using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterMessaging.DTO.ResponseDTOs.MessagingResponses
{
    public class MessageParticipantResponse
    {
        public Guid ProfileId { get; set; }
        public string DisplayName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Email { get; set; }
    }
}
