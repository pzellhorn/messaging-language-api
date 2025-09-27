using Microsoft.AspNetCore.Mvc;

namespace FlutterMessaging.API.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class ProfileSettingsController : ControllerBase
    {
        private readonly ILogger<ProfileSettingsController> _logger;

        public ProfileSettingsController(ILogger<ProfileSettingsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(nameof(GetProfileSettings))]
        public Task<Guid> GetProfileSettings(Guid profileId, CancellationToken cancellationToken)
        {
            return default;
        }
    }
}
