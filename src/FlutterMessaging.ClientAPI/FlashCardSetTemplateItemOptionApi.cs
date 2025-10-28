using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.ClientAPI
{
    public class FlashCardSetTemplateItemOptionApi(ApiTransport api) : BaseClientApi<FlashCardSetTemplateItemOptionRequest, FlashCardSetTemplateItemOptionResponse>(api, "FlashCardSetTemplateItemOption")
    {
    }
}
