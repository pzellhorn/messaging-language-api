using FlutterMessaging.API.Controllers.Base;
using FlutterMessaging.DTO;
using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace FlutterMessaging.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalIdentityController(IExternalIdentityDtoAdapter logic) : BaseController<ExternalIdentityRequest, ExternalIdentityResponse>(logic)
    {
        [HttpPost(nameof(AuthenticateWithGoogle))]
        public async Task<ActionResult> AuthenticateWithGoogle(
            [FromBody] AuthRequest request,
            CancellationToken cancellationToken = default)
        {
            await logic.AuthenticateWithGoogle(request.Token, "", cancellationToken);
            return Ok();
        }
    }
}
