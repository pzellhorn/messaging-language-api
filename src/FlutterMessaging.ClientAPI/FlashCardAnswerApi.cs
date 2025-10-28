using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.ClientAPI
{
    public class FlashCardAnswerApi(ApiTransport api) : BaseClientApi<FlashCardAnswerRequest, FlashCardAnswerResponse>(api, "FlashCardAnswer")
    {
    }

}
