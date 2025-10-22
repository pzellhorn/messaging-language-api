using FlutterMessaging.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class FlashCardSetTemplateApi(ApiTransport api) : BaseClientApi<FlashCardSetTemplateRequest, FlashCardSetTemplateResponse>(api, "FlashCardSetTemplate")
    {
        public Task<Guid> UpsertFlashCardSetAsync(CancellationToken cancellationToken = default) => Post<Guid>("UpsertFlashCardSet", cancellationToken);

    }
}
