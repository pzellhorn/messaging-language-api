using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.ClientAPI
{
    public class SessionApi(ApiTransport api) : BaseClientApi<SessionRequest, SessionResponse>(api, "Session")
    {
    }
}
