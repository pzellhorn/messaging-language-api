using System.Linq.Expressions;
using FlutterMessaging.State.Base.Interfaces;
using FlutterMessaging.State.Data;
using Microsoft.EntityFrameworkCore;

namespace FlutterMessaging.State.Base
{
    public class BaseRepository<T>(MessagingDbContext db) : IBaseRepository<T> where T : class, IIsDeleted, IPrimaryKeySelector<T>
    {
        public Task<T?> Get(Guid id, bool excludeSoftDelete = true, CancellationToken cancellationToken = default)
            => db.Get<T>(id, excludeSoftDelete, cancellationToken); 

        public Task<List<T>> GetFor(Guid foreignKey, string propertyName, bool excludeSoftDelete = true, CancellationToken cancellationToken = default)
            => db.GetFor<T>(foreignKey, propertyName, excludeSoftDelete, cancellationToken);

        public Task<List<T>> GetFor(Guid foreignKey, Expression<Func<T, Guid?>> property, bool excludeSoftDelete = true, CancellationToken cancellationToken = default)
            => db.GetFor(foreignKey, property, excludeSoftDelete, cancellationToken);

        public Task<T> Upsert(T entity, CancellationToken cancellationToken = default)
            => db.Upsert(entity, cancellationToken);

        public Task<bool> Delete(Guid id, CancellationToken cancellationToken = default)
            => db.Delete<T>(id, cancellationToken); 
    }
}
