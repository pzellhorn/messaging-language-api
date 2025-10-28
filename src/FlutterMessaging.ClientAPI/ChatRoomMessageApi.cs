using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.ClientAPI
{
    public class ChatRoomMessageApi(ApiTransport api) : BaseClientApi<ChatRoomMessageRequest, ChatRoomMessageResponse>(api, "ChatRoomMessage")
    {
    }
}

