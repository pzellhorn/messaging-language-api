using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.ClientAPI.Base;
using FlutterMessaging.State.Data.Entities;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;

namespace FlutterMessaging.ClientAPI
{
    public class FlashCardSetTemplateApi(ApiTransport api) : BaseClientApi<FlashCardSetTemplateRequest, FlashCardSetTemplateResponse>(api, "FlashCardSetTemplate")
    {
        public Task<Guid> UpsertFlashCardSetAsync(CancellationToken cancellationToken = default) => Post<Guid>("UpsertFlashCardSet", cancellationToken);

    }
}
