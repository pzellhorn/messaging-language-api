using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterMessaging.DTO.RequestDTOs
{
    public class RefreshRequest
    {
        public Guid SessionId { get; set; }
        public string RefreshToken { get; set; }
    }
}
