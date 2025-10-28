using pzellhorn.Core.ClientAPI.Base;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.ClientAPI
{
    public class FlashCardSetTemplateApi(ApiTransport api) : BaseClientApi<FlashCardSetTemplateRequest, FlashCardSetTemplateResponse>(api, "FlashCardSetTemplate")
    {
        public Task<Guid> UpsertFlashCardSetAsync(CancellationToken cancellationToken = default) => Post<Guid>("UpsertFlashCardSet", cancellationToken);

    }
}
