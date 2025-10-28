using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.ClientAPI
{
    public class LanguageWordFrequencyApi(ApiTransport api) : BaseClientApi<LanguageWordFrequencyRequest, LanguageWordFrequencyResponse>(api, "LanguageWordFrequency")
    {
    }
}
