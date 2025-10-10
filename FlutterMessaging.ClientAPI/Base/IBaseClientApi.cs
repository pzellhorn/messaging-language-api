using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterMessaging.ClientAPI.Base
{
    public interface IBaseClientApi<T> where T : class
    {
        Task<T?> Get(Guid id, CancellationToken cancellationToken = default);
        Task<T> Upsert(T entity, CancellationToken cancellationToken = default);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken = default);
    }
}
