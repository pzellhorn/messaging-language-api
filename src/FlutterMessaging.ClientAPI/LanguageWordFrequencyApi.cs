using FlutterMessaging.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class LanguageWordFrequencyApi(ApiTransport api) : BaseClientApi<LanguageWordFrequencyRequest, LanguageWordFrequencyResponse>(api, "LanguageWordFrequency")
    {
    }
}
