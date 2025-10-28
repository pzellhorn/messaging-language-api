using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.ClientAPI
{
    public class FlashCardSetTemplateItemApi(ApiTransport api) : BaseClientApi<FlashCardSetTemplateItemRequest, FlashCardSetTemplateItemResponse>(api, "FlashCardSetTemplateItem")
    {
    }
}
