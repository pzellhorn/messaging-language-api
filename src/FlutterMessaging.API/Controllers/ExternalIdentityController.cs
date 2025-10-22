using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.DTO.Types;
using Microsoft.AspNetCore.Mvc;
using pzellhorn.Core;

namespace FlutterMessaging.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalIdentityController(IExternalIdentityDtoAdapter logic) : BaseController<ExternalIdentityRequest, ExternalIdentityResponse>(logic)
    {
        [HttpPost(nameof(AuthenticateWithGoogle))]
        public async Task<ActionResult<AuthTokenResponse>> AuthenticateWithGoogle(
            [FromBody] AuthRequest request,
            CancellationToken cancellationToken = default)
        { 
            return Ok(await logic.AuthenticateWithGoogle(request.Token, "", request.deviceId, cancellationToken));
        }

        [HttpPost(nameof(Refresh))]
        public async Task<ActionResult<AuthTokenResponse>> Refresh([FromBody] RefreshRequest request, CancellationToken cancellationToken = default)
        {  
            return Ok(await logic.RotateRefreshToken(request.SessionId, request.RefreshToken, cancellationToken));
        }
    }
}
