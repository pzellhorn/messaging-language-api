using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.ClientAPI
{
    public class ChatRoomMemberApi(ApiTransport api) : BaseClientApi<ChatRoomMemberRequest, ChatRoomMemberResponse>(api, "ChatRoomMember")
    {
    }
}
