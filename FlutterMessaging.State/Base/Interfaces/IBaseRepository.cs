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
        Task<T?> Get(Guid id, bool excludeSoftDelete = true, CancellationToken cancellationToken = default);  
        Task<List<T>> GetFor(Guid foreignKey, string propertyName, bool excludeSoftDelete = true, CancellationToken cancellationToken = default);
        Task<List<T>> GetFor(Guid foreignKey, Expression<Func<T, Guid?>> property, bool excludeSoftDelete = true, CancellationToken cancellationToken = default);

        Task<T> Upsert(T entity, CancellationToken cancellationToken = default);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken = default);

    }


}
