using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterMessaging.Logic.ServiceLogic
{ 
    public interface IUserContext
    {
        Guid GetProfileIdOrThrow();
        string? GetDeviceId();
    }
}
