using FlutterMessaging.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class ChatRoomMemberApi(ApiTransport api) : BaseClientApi<ChatRoomMemberRequest, ChatRoomMemberResponse>(api, "ChatRoomMember")
    {
    }
}
