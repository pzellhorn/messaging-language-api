using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.Logic.EntityLogic;
using FlutterMessaging.State.Data.Entities;
using pzellhorn.Core.Logic.Base;
using pzellhorn.Core.Logic.Base.DTOAdapter;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class ChatRoomDtoAdapter(
        ChatRoomLogic chatRoomLogic,
        IDTOMapper<ChatRoom, ChatRoomRequest, ChatRoomResponse> mapper)
        : DtoLogicAdapter<ChatRoom, ChatRoomRequest, ChatRoomResponse>(chatRoomLogic, mapper), IChatRoomDtoAdapter
    {
    }
}
