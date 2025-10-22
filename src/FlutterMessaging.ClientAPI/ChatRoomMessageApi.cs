using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class ChatRoomMessageApi(ApiTransport api) : BaseClientApi<ChatRoomMessageRequest, ChatRoomMessageResponse>(api, "ChatRoomMessage")
    {
    }
}

