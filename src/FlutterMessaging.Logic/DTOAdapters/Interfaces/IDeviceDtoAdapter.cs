using FlutterMessaging.DTO.RequestDTOs.EntityRequests;
using FlutterMessaging.DTO.RequestDTOs.MessagingRequests;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.DTO.ResponseDTOs.MessagingResponses;
using pzellhorn.Core.Logic.Base.DTOAdapter;

namespace FlutterMessaging.Logic.DTOAdapters.Interfaces
{
    public interface IDeviceDtoAdapter
      : IDtoLogicAdapter<DeviceRequest, DeviceResponse>
    { 
        Task<DeviceResponse> RegisterDevice(DeviceRequest request, CancellationToken cancellationToken = default);
    }
}
