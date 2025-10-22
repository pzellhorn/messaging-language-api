using FlutterMessaging.Logic.Base;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.EntityLogic
{
    public class ChatRoomLogic(IBaseRepository<ChatRoom> chatRoomRepository) : BaseLogic<ChatRoom>(chatRoomRepository)
    {

    }
}
