using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using Microsoft.AspNetCore.Mvc;
using pzellhorn.Core;

namespace FlutterMessaging.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JwtKeyController(IJwtKeyDtoAdapter logic) : BaseController<JwtKeyRequest, JwtKeyResponse>(logic)
    {
    }
}
