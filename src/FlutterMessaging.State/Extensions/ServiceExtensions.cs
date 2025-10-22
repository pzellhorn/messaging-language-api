using pzellhorn.Core.State.Base;
using pzellhorn.Core.State.Base.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FlutterMessaging.State.Extensions
{
    public static class FlutterMessagingServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            return services;
        }
    }
}
