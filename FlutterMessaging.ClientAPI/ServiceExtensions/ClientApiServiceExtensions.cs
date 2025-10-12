using System.Net;
using FlutterMessaging.ClientAPI.Base;
using Microsoft.Extensions.DependencyInjection;

namespace FlutterMessaging.ClientAPI.ServiceExtensions
{
    public static class ClientApiServiceExtensions
    {
        public static IServiceCollection AddClientApiExtensions(this IServiceCollection services, Uri baseAddress)
        {
            services.AddHttpClient<ApiTransport>(x => x.BaseAddress = baseAddress); 

            //ClientApi Implementations
            services.AddScoped<FlashCardSetTemplateApi>(); 

            return services;
        }
    }
}
