using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.ClientAPI.Base;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.ClientAPI
{ 
    public class ChatRoomApi(ApiTransport api) : BaseClientApi<ChatRoom>(api, "ChatRoom")
    {
    }
}
