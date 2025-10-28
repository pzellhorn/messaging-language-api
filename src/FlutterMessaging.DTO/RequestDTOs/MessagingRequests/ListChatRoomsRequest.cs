using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterMessaging.DTO.RequestDTOs.MessagingRequests
{
    public class ListChatRoomsRequest
    {  
        public int Limit { get; set; } = 20;
    }
}
