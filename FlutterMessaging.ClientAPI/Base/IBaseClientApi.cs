using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterMessaging.ClientAPI.Base
{
    public interface IBaseClientApi<TReq, TRes>
    {
        Task<TRes?> Get(Guid id, CancellationToken cancellationToken = default);
        Task<TRes> Upsert(TReq request, CancellationToken cancellationToken = default);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken = default);
    }
}
