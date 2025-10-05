using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FlutterMessaging.State.Base.Interfaces
{
    public interface IBaseRepository<T> where T : class, IIsDeleted, IPrimaryKeySelector<T>
    {
        Task<T?> Get(Guid id, CancellationToken cancellationToken = default, bool excludeSoftDelete = true);
        Task<List<T>> GetFor<TKey>(TKey key, Expression<Func<T, TKey>> property, CancellationToken cancellationToken = default, bool excludeSoftDelete = true);

        Task<T> Upsert(T entity, CancellationToken cancellationToken = default);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken = default);

    }


}
