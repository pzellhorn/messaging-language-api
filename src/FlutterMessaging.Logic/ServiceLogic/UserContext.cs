using System.Security.Claims; 
using Microsoft.AspNetCore.Http;

namespace FlutterMessaging.Logic.ServiceLogic
{  
    //We inject this into the DTO Adapter
    public class UserContext(IHttpContextAccessor accessor) : IUserContext
    { 
        /// <summary>
        /// Reads ProfileId off JWT token
        /// </summary>
        /// <returns>Caller ProfileId</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public Guid GetProfileIdOrThrow()
        {
            ClaimsPrincipal user = accessor.HttpContext?.User ?? throw new UnauthorizedAccessException("Not authenticated.");
            string? pid = user.FindFirst("pid")?.Value;
            if (Guid.TryParse(pid, out var profileId)) return profileId; 
             
            throw new UnauthorizedAccessException("ProfileId claim missing/invalid.");
        }

        /// <summary>
        /// Reads DeviceId off JWT token
        /// </summary>
        /// <returns>Caller DeviceId</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public string? GetDeviceId() => accessor.HttpContext?.User?.FindFirst("did")?.Value;
    }
}
