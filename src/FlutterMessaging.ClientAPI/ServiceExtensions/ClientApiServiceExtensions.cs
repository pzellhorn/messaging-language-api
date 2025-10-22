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
            services.AddScoped<ChatRoomApi>();
            services.AddScoped<ChatRoomMemberApi>();
            services.AddScoped<ChatRoomMessageApi>();
            services.AddScoped<ExternalIdentityApi>();
            services.AddScoped<FlashCardAnswerApi>();
            services.AddScoped<FlashCardSetTemplateApi>();
            services.AddScoped<FlashCardSetTemplateItemApi>();
            services.AddScoped<FlashCardSetTemplateItemOptionApi>();
            services.AddScoped<JwtKeyApi>();
            services.AddScoped<LanguageApi>();
            services.AddScoped<LanguageTranslationApi>();
            services.AddScoped<LanguageWordFrequencyApi>();
            services.AddScoped<ProfileApi>();
            services.AddScoped<ProfileSettingApi>();
            services.AddScoped<ProfileSettingOptionApi>();
            services.AddScoped<RefreshTokenApi>();
            services.AddScoped<SessionApi>();

            return services;
        }
    }
}
