using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class FlashCardSetTemplateItemOptionApi(ApiTransport api) : BaseClientApi<FlashCardSetTemplateItemOptionRequest, FlashCardSetTemplateItemOptionResponse>(api, "FlashCardSetTemplateItemOption")
    {
    }
}
