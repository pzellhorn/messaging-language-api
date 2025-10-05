using FlutterMessaging.API.Controllers.Base;
using FlutterMessaging.Logic.Base;
using FlutterMessaging.State.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.Auth;
using FlutterMessaging.Logic;

namespace FlutterMessaging.API.Controllers
{  
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalIdentityController(ExternalIdentityLogic externalIdentityLogic) : BaseController<ExternalIdentity>(externalIdentityLogic)
    {  
        [HttpPost(nameof(AuthenticateWithGoogle))]
        public async Task<ActionResult<Profile>> AuthenticateWithGoogle(string token, string nonce, CancellationToken cancellationToken)
        { 
            return Ok(await externalIdentityLogic.AuthenticateWithGoogle(token, nonce, cancellationToken));
        }
         
    }
}
