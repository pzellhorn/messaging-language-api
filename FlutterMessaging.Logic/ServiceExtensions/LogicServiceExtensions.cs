using FlutterMessaging.Logic.Base; 
using Microsoft.Extensions.DependencyInjection;

namespace FlutterMessaging.Logic.ServiceExtensions
{
    public static class LogicServiceExtensions
    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseLogic<>), typeof(BaseLogic<>));

            services.AddScoped<ChatRoomLogic>();
            services.AddScoped<ChatRoomMemberLogic>();
            services.AddScoped<ChatRoomMessageLogic>();
            services.AddScoped<ExternalIdentityLogic>();
            services.AddScoped<FlashCardAnswerLogic>();
            services.AddScoped<FlashCardSetTemplateLogic>();
            services.AddScoped<FlashCardSetTemplateItemLogic>();
            services.AddScoped<FlashCardSetTemplateItemOptionLogic>();
            services.AddScoped<JwtKeyLogic>();
            services.AddScoped<LanguageLogic>();
            services.AddScoped<LanguageTranslationLogic>();
            services.AddScoped<LanguageWordFrequencyLogic>();
            services.AddScoped<ProfileLogic>();
            services.AddScoped<ProfileSettingLogic>();
            services.AddScoped<ProfileSettingOptionLogic>();
            services.AddScoped<RefreshTokenLogic>();
            services.AddScoped<SessionLogic>();



            return services;
        }
    } 
}
