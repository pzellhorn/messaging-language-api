using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.DTO.DTOAdapters.Interfaces
{
    public interface IChatRoomMemberDtoAdapter
        : IDtoLogicAdapter<ChatRoomMemberRequest, ChatRoomMemberResponse>
    {
    }
}
