using FlutterMessaging.State.StateLogic;
using FlutterMessagingApi;
using Microsoft.AspNetCore.Mvc;

namespace FlutterMessaging.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController(ProfileLogic profileLogic) : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger; 

        [HttpGet(nameof(Login))]
        public Task<Guid> Login(string username, string password, CancellationToken cancellationToken)
        {
            return default;
        }

        [HttpPost(nameof(UpsertProfile))]
        public async Task<ActionResult> UpsertProfile(string profile_name, CancellationToken cancellationToken)
        {
            return Ok(await profileLogic.UpsertProfile(profile_name));
        }
    }
}
