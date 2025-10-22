using FlutterMessaging.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class ExternalIdentityApi(ApiTransport api) : BaseClientApi<ExternalIdentityRequest, ExternalIdentityResponse>(api, "ExternalIdentity")
    {
    }
}
