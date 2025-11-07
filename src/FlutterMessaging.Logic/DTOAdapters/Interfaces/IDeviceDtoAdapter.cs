using FlutterMessaging.DTO.RequestDTOs.EntityRequests;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using pzellhorn.Core.Logic.Base.DTOAdapter;

namespace FlutterMessaging.Logic.DTOAdapters.Interfaces
{
    public interface IDeviceDtoAdapter
      : IDtoLogicAdapter<DeviceRequest, DeviceResponse>
    {

    }
}
