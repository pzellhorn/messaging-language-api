using FlutterMessaging.DTO.RequestDTOs.EntityRequests;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using pzellhorn.Core.ClientAPI.Base;

namespace FlutterMessaging.ClientAPI
{
    public class DeviceApi(ApiTransport api) : BaseClientApi<DeviceRequest, DeviceResponse>(api, "Device")
    {
    }
}
