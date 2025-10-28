using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.ClientAPI
{
    public class ExternalIdentityApi(ApiTransport api) : BaseClientApi<ExternalIdentityRequest, ExternalIdentityResponse>(api, "ExternalIdentity")
    {
    }
}
