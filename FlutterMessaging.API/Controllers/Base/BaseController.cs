using FlutterMessaging.Logic.Base.DTOAdapter;
using Microsoft.AspNetCore.Mvc;

namespace FlutterMessaging.API.Controllers.Base
{
    [ApiController]
    public abstract class BaseController<TReq, TRes>(
    IDtoLogicAdapter<TReq, TRes> logic) : ControllerBase
    {
        [HttpGet(nameof(Get))]
        public async Task<ActionResult<TRes>> Get(Guid id, CancellationToken cancellationToken)
            => (await logic.Get(id, cancellationToken)) is { } dto ? Ok(dto) : NotFound();

        [HttpGet(nameof(GetFor))]
        public async Task<ActionResult<List<TRes>>> GetFor(string key, string propertyName, CancellationToken cancellationToken = default)
            => Ok(await logic.GetFor(key, propertyName, cancellationToken));

        [HttpPost(nameof(Upsert))]
        public async Task<ActionResult<TRes>> Upsert([FromBody] TReq request, CancellationToken cancellationToken)
            => Ok(await logic.Upsert(request, cancellationToken));

        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
            => await logic.Delete(id, cancellationToken) ? NoContent() : NotFound();
    } 
}

