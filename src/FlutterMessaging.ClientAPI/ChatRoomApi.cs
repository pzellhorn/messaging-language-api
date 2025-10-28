using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.ClientAPI
{
    public class ChatRoomApi(ApiTransport api) : BaseClientApi<ChatRoomRequest, ChatRoomResponse>(api, "ChatRoom")
    {
    }
}
