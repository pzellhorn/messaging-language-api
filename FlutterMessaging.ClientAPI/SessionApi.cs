using FlutterMessaging.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class SessionApi(ApiTransport api) : BaseClientApi<SessionRequest, SessionResponse>(api, "Session")
    {
    }
}
