using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.State.Base.Interfaces;

namespace FlutterMessaging.Logic.Base
{
    public class BaseLogic<T>(IBaseRepository<T> baseRepository) : IBaseLogic<T>
       where T : class, IIsDeleted, IPrimaryKeySelector<T>
    {
        public Task<T?> Get(Guid id, bool excludeSoftDelete = true, CancellationToken cancellationToken = default) => baseRepository.Get(id, excludeSoftDelete, cancellationToken);

        public async Task<T> Upsert(T entity, CancellationToken ct = default) => await baseRepository.Upsert(entity, ct);  

        public async Task<bool> Delete(Guid id, CancellationToken ct = default) 
            => await baseRepository.Delete(id, ct);

        public async Task<List<T>> GetFor(Guid foreignKey, string propertyName, bool excludeSoftDelete = true, CancellationToken cancellationToken = default)
            => await baseRepository.GetFor(foreignKey, propertyName, excludeSoftDelete, cancellationToken);

        public Task<List<T>> GetFor(Guid foreignKey, Expression<Func<T, Guid?>> property, bool excludeSoftDelete = true, CancellationToken cancellationToken = default)
            => baseRepository.GetFor(foreignKey, property, excludeSoftDelete, cancellationToken); 
    }
}
