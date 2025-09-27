using FlutterMessagingApi;
using Microsoft.AspNetCore.Mvc;

namespace FlutterMessaging.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
        }

        [HttpGet(nameof(Login))]
        public Task<Guid> Login(string username, string password, CancellationToken cancellationToken)
        {
            return default;
        }
    }
}
