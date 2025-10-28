using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.ClientAPI
{
    public class JwtKeyApi(ApiTransport api) : BaseClientApi<JwtKeyRequest, JwtKeyResponse>(api, "JwtKey")
    {
    }
}
