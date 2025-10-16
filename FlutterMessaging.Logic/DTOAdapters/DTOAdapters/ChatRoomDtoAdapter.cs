using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class ChatRoomDtoAdapter(
        ChatRoomLogic chatRoomLogic,
        IDTOMapper<ChatRoom, ChatRoomRequest, ChatRoomResponse> mapper)
        : DtoLogicAdapter<ChatRoom, ChatRoomRequest, ChatRoomResponse>(chatRoomLogic, mapper), IChatRoomDtoAdapter
    {
    }
}
