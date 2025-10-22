using FlutterMessaging.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class ChatRoomApi(ApiTransport api) : BaseClientApi<ChatRoomRequest, ChatRoomResponse>(api, "ChatRoom")
    {
    }
}
