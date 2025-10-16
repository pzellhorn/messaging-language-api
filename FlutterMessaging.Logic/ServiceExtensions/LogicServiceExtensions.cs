using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.Logic.DTOAdapters.DTOAdapters;
using FlutterMessaging.Logic.DTOMappers;
using FlutterMessaging.State.Data.Entities;
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
             
            //Mapper + dto adapters
            services.AddScoped<IDTOMapper<ChatRoom, ChatRoomRequest, ChatRoomResponse>, ChatRoomMapper>();
            services.AddScoped<IChatRoomDtoAdapter, ChatRoomDtoAdapter>();
             
            services.AddScoped<IDTOMapper<ChatRoomMember, ChatRoomMemberRequest, ChatRoomMemberResponse>, ChatRoomMemberMapper>();
            services.AddScoped<IChatRoomMemberDtoAdapter, ChatRoomMemberDtoAdapter>();
             
            services.AddScoped<IDTOMapper<ChatRoomMessage, ChatRoomMessageRequest, ChatRoomMessageResponse>, ChatRoomMessageMapper>();
            services.AddScoped<IChatRoomMessageDtoAdapter, ChatRoomMessageDtoAdapter>();
             
            services.AddScoped<IDTOMapper<ExternalIdentity, ExternalIdentityRequest, ExternalIdentityResponse>, ExternalIdentityMapper>();
            services.AddScoped<IExternalIdentityDtoAdapter, ExternalIdentityDtoAdapter>();
             
            services.AddScoped<IDTOMapper<FlashCardAnswer, FlashCardAnswerRequest, FlashCardAnswerResponse>, FlashCardAnswerMapper>();
            services.AddScoped<IFlashCardAnswerDtoAdapter, FlashCardAnswerDtoAdapter>();
             
            services.AddScoped<IDTOMapper<FlashCardSetTemplate, FlashCardSetTemplateRequest, FlashCardSetTemplateResponse>, FlashCardSetTemplateMapper>();
            services.AddScoped<IFlashCardSetTemplateDtoAdapter, FlashCardSetTemplateDtoAdapter>();
             
            services.AddScoped<IDTOMapper<FlashCardSetTemplateItem, FlashCardSetTemplateItemRequest, FlashCardSetTemplateItemResponse>, FlashCardSetTemplateItemMapper>();
            services.AddScoped<IFlashCardSetTemplateItemDtoAdapter, FlashCardSetTemplateItemDtoAdapter>();
             
            services.AddScoped<IDTOMapper<FlashCardSetTemplateItemOption, FlashCardSetTemplateItemOptionRequest, FlashCardSetTemplateItemOptionResponse>, FlashCardSetTemplateItemOptionMapper>();
            services.AddScoped<IFlashCardSetTemplateItemOptionDtoAdapter, FlashCardSetTemplateItemOptionDtoAdapter>();
             
            services.AddScoped<IDTOMapper<JwtKey, JwtKeyRequest, JwtKeyResponse>, JwtKeyMapper>();
            services.AddScoped<IJwtKeyDtoAdapter, JwtKeyDtoAdapter>();
             
            services.AddScoped<IDTOMapper<Language, LanguageRequest, LanguageResponse>, LanguageMapper>();
            services.AddScoped<ILanguageDtoAdapter, LanguageDtoAdapter>();
             
            services.AddScoped<IDTOMapper<LanguageTranslation, LanguageTranslationRequest, LanguageTranslationResponse>, LanguageTranslationMapper>();
            services.AddScoped<ILanguageTranslationDtoAdapter, LanguageTranslationDtoAdapter>();
             
            services.AddScoped<IDTOMapper<LanguageWordFrequency, LanguageWordFrequencyRequest, LanguageWordFrequencyResponse>, LanguageWordFrequencyMapper>();
            services.AddScoped<ILanguageWordFrequencyDtoAdapter, LanguageWordFrequencyDtoAdapter>();
             
            services.AddScoped<IDTOMapper<Profile, ProfileRequest, ProfileResponse>, ProfileMapper>();
            services.AddScoped<IProfileDtoAdapter, ProfileDtoAdapter>();
             
            services.AddScoped<IDTOMapper<ProfileSetting, ProfileSettingRequest, ProfileSettingResponse>, ProfileSettingMapper>();
            services.AddScoped<IProfileSettingDtoAdapter, ProfileSettingDtoAdapter>();
             
            services.AddScoped<IDTOMapper<ProfileSettingOption, ProfileSettingOptionRequest, ProfileSettingOptionResponse>, ProfileSettingOptionMapper>();
            services.AddScoped<IProfileSettingOptionDtoAdapter, ProfileSettingOptionDtoAdapter>();
             
            services.AddScoped<IDTOMapper<RefreshToken, RefreshTokenRequest, RefreshTokenResponse>, RefreshTokenMapper>();
            services.AddScoped<IRefreshTokenDtoAdapter, RefreshTokenDtoAdapter>();
             
            services.AddScoped<IDTOMapper<Session, SessionRequest, SessionResponse>, SessionMapper>();
            services.AddScoped<ISessionDtoAdapter, SessionDtoAdapter>();

            return services;


            return services;
        }
    } 
}
