using FlutterMessaging.Logic.Base;
using FlutterMessaging.State.Data.Entities;
using FlutterMessaging.State.StateLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FlutterMessaging.Logic.ServiceExtensions
{
    public static class LogicServiceExtensions
    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseLogic<>), typeof(BaseLogic<>));
            services.AddScoped<ProfileLogic>();

            return services;
        }
    } 
}
