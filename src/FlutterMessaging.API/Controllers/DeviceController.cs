using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.RequestDTOs.EntityRequests;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.Logic.DTOAdapters.Interfaces;
using Microsoft.AspNetCore.Mvc;
using pzellhorn.Core;

namespace FlutterMessaging.API.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController(IDeviceDtoAdapter logic) : BaseController<DeviceRequest, DeviceResponse>(logic)
    {
    }
} 