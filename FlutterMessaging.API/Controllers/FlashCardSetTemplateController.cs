using FlutterMessaging.API.Controllers.Base;
using FlutterMessaging.Logic;
using FlutterMessaging.Logic.Base;
using FlutterMessaging.State.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlutterMessaging.API.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class FlashCardSetTemplateController(FlashCardSetTemplateLogic flashCardSetTemplateLogic) : BaseController<FlashCardSetTemplate>(flashCardSetTemplateLogic)
    {
        [HttpPost(nameof(UpsertFlashCardSet))]
        public Task<Guid> UpsertFlashCardSet(CancellationToken cancellationToken)
        {
            return flashCardSetTemplateLogic.UpsertFlashCardSet(cancellationToken);
        } 
    } 
} 