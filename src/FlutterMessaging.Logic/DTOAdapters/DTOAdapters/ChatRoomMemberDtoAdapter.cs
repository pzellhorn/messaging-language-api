using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;  
using FlutterMessaging.Logic.EntityLogic;
using FlutterMessaging.State.Data.Entities;
using pzellhorn.Core.Logic.Base;
using pzellhorn.Core.Logic.Base.DTOAdapter;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class ChatRoomMemberDtoAdapter(
        ChatRoomMemberLogic chatRoomMemberLogic,
        IDTOMapper<ChatRoomMember, ChatRoomMemberRequest, ChatRoomMemberResponse> mapper)
        : DtoLogicAdapter<ChatRoomMember, ChatRoomMemberRequest, ChatRoomMemberResponse>(chatRoomMemberLogic, mapper),
          IChatRoomMemberDtoAdapter
    {
    }
}
