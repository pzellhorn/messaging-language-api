using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FlutterMessaging.Logic.ServiceExtensions
{
    public static class SecurityExtensions
    {
        public static Guid GetProfileIdOrThrow(this ClaimsPrincipal user)
        {
            if (user?.Identity?.IsAuthenticated != true)
                throw new UnauthorizedAccessException("Not authenticated.");

            if (Guid.TryParse(user.FindFirst("pid")?.Value, out Guid profileId))
                return profileId; 

            throw new UnauthorizedAccessException("ProfileId claim missing or invalid.");
        }
    }
}
