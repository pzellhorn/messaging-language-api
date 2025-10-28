using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.ClientAPI
{
    public class LanguageTranslationApi(ApiTransport api) : BaseClientApi<LanguageTranslationRequest, LanguageTranslationResponse>(api, "LanguageTranslation")
    {
    }
}
