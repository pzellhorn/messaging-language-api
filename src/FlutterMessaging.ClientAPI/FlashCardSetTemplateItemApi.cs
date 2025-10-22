using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class FlashCardSetTemplateItemApi(ApiTransport api) : BaseClientApi<FlashCardSetTemplateItemRequest, FlashCardSetTemplateItemResponse>(api, "FlashCardSetTemplateItem")
    {
    }
}
