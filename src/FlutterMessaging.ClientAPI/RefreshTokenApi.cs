using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class RefreshTokenApi(ApiTransport api) : BaseClientApi<RefreshTokenRequest,RefreshTokenResponse>(api, "RefreshToken")
    {
    }
}
