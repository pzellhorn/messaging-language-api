using FlutterMessaging.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class LanguageApi(ApiTransport api) : BaseClientApi<LanguageRequest, LanguageResponse>(api, "Language")
    {
    }
}
