using FlutterMessaging.Logic.Base;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.EntityLogic
{
    public class ChatRoomMemberLogic(IBaseRepository<ChatRoomMember> chatRoomMemberRepository) : BaseLogic<ChatRoomMember>(chatRoomMemberRepository)
    {

    }
}
