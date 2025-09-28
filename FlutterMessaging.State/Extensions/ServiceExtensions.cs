using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Base;
using Microsoft.Extensions.DependencyInjection;
using FlutterMessaging.State.Data.Entities;

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
