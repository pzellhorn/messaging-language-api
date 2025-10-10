using FlutterMessaging.API.Controllers.Base;
using FlutterMessaging.Logic;
using FlutterMessaging.State.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlutterMessaging.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController(ProfileLogic profileLogic) : BaseController<Profile>(profileLogic)
    { 

        [HttpGet(nameof(Login))]
        public Task<Guid> Login(string username, string password, CancellationToken cancellationToken)
        {
            return default;
        }

        [HttpPost(nameof(UpsertProfile))]
        public async Task<ActionResult<Profile>> UpsertProfile(string profile_name, CancellationToken cancellationToken)
        {
            return Ok(await profileLogic.UpsertProfile(profile_name));
        }
    }
}
