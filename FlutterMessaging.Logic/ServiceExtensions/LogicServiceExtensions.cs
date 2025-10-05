using FlutterMessaging.Logic.Base; 
using Microsoft.Extensions.DependencyInjection;

namespace FlutterMessaging.Logic.ServiceExtensions
{
    public static class LogicServiceExtensions
    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseLogic<>), typeof(BaseLogic<>));
            services.AddScoped<ProfileLogic>();
            services.AddScoped<ExternalIdentityLogic>();



            return services;
        }
    } 
}
