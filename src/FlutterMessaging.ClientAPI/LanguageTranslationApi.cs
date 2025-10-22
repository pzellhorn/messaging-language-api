using FlutterMessaging.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class LanguageTranslationApi(ApiTransport api) : BaseClientApi<LanguageTranslationRequest, LanguageTranslationResponse>(api, "LanguageTranslation")
    {
    }
}
