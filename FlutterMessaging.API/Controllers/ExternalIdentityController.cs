using FlutterMessaging.API.Controllers.Base;
using FlutterMessaging.DTO;
using FlutterMessaging.Logic;
using FlutterMessaging.State.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlutterMessaging.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalIdentityController(ExternalIdentityLogic externalIdentityLogic) : BaseController<ExternalIdentity>(externalIdentityLogic)
    {  
        [HttpPost(nameof(AuthenticateWithGoogle))]
        public async Task<ActionResult<Profile>> AuthenticateWithGoogle([FromBody] AuthRequest request, CancellationToken cancellationToken = default)
        { 
            return Ok(await externalIdentityLogic.AuthenticateWithGoogle(request.Token , "", cancellationToken));
        }
         
    }
}
