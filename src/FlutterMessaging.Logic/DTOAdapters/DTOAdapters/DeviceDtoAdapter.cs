using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.RequestDTOs.EntityRequests;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.Logic.DTOAdapters.Interfaces;
using FlutterMessaging.Logic.EntityLogic;
using FlutterMessaging.State.Data.Entities;
using pzellhorn.Core.Logic.Base;
using pzellhorn.Core.Logic.Base.DTOAdapter;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{ 
    public class DeviceDtoAdapter(
       DeviceLogic deviceLogic,
       IDTOMapper<Device, DeviceRequest, DeviceResponse> mapper)
       : DtoLogicAdapter<Device, DeviceRequest, DeviceResponse>(deviceLogic, mapper),
         IDeviceDtoAdapter
    {
    }
}
 