using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.Logic.EntityLogic;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class ChatRoomMessageDtoAdapter(
        ChatRoomMessageLogic chatRoomMessageLogic,
        IDTOMapper<ChatRoomMessage, ChatRoomMessageRequest, ChatRoomMessageResponse> mapper)
        : DtoLogicAdapter<ChatRoomMessage, ChatRoomMessageRequest, ChatRoomMessageResponse>(chatRoomMessageLogic, mapper),
          IChatRoomMessageDtoAdapter
    {
    }
}
