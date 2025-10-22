using FlutterMessaging.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class JwtKeyApi(ApiTransport api) : BaseClientApi<JwtKeyRequest, JwtKeyResponse>(api, "JwtKey")
    {
    }
}
