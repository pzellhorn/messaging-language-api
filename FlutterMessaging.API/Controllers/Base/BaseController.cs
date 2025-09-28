using FlutterMessaging.Logic.Base;
using FlutterMessaging.State.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlutterMessaging.API.Controllers.Base
{
    [ApiController]
    public abstract class BaseController<T> (IBaseLogic<T> baseLogic) : ControllerBase
     where T : class, IIsDeleted, IPrimaryKeySelector<T>
    {  

        // GET api/{controller}/{id}
        [HttpGet(nameof(Get))]
        public async Task<ActionResult<T>> Get(Guid id, CancellationToken cancellationToken) => Ok(await baseLogic.Get(id, cancellationToken: cancellationToken)); 

        // POST api/{controller}
        [HttpPost(nameof(Upsert))]
        public Task<T> Upsert([FromBody] T entity, CancellationToken cancellationToken) => baseLogic.Upsert(entity, cancellationToken);

        // DELETE api/{controller}/{id}
        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct) => await baseLogic.Delete(id, ct) ? NoContent() : NotFound(); 
    }
}
