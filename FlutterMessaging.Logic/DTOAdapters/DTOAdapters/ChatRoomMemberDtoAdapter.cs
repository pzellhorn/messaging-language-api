using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

using FlutterMessaging.DTO.DTOAdapters.Interfaces;

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
