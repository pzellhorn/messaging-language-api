using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.RequestDTOs.EntityRequests;
using FlutterMessaging.DTO.RequestDTOs.MessagingRequests;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.DTO.ResponseDTOs.MessagingResponses;
using FlutterMessaging.Logic.DTOAdapters.Interfaces;
using FlutterMessaging.Logic.EntityLogic;
using FlutterMessaging.Logic.ServiceLogic;
using FlutterMessaging.State.Data.Entities;
using pzellhorn.Core.Logic.Base;
using pzellhorn.Core.Logic.Base.DTOAdapter;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{ 
    public class DeviceDtoAdapter(
       DeviceLogic deviceLogic,
              IUserContext currentUser,
       IDTOMapper<DeviceInstallation, DeviceRequest, DeviceResponse> mapper)
       : DtoLogicAdapter<DeviceInstallation, DeviceRequest, DeviceResponse>(deviceLogic, mapper),
         IDeviceDtoAdapter
    { 
        public Task<DeviceResponse> RegisterDevice(DeviceRequest request, CancellationToken cancellationToken = default)
           => deviceLogic.RegisterDevice(currentUser.GetProfileIdOrThrow(), request, cancellationToken);
    }
}
 