using System.Linq.Expressions;
using FlutterMessaging.State.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlutterMessaging.State.Data
{

    // To include previously-deleted items in your result set, ensure the "excludeSoftDelete" flag is false.  
    // The Delete function below will mark an item isDeleted = true, rather than actually delete the item.
    // All calls to this class should go through BaseRepository or an overload of BaseRepository

    public static class BaseCrudLogic
    { 
        //  gets & stores Primary Key for each model 
        private static class KeyCache<T> where T : class, IPrimaryKeySelector<T>
        {
            public static readonly Func<T, Guid> Get = T.PrimaryKey.Compile();
        }

        private sealed class ReplaceParamVisitor : ExpressionVisitor
        {
            private readonly ParameterExpression _from, _to;
            public ReplaceParamVisitor(ParameterExpression from, ParameterExpression to) { _from = from; _to = to; }
            protected override Expression VisitParameter(ParameterExpression node) => node == _from ? _to : base.VisitParameter(node);
        }

        private static Expression<Func<T, bool>> BuildKeyPredicate<T>(Guid id, bool includeDeleted)
           where T : class, IIsDeleted, IPrimaryKeySelector<T>
        {
            Expression<Func<T, Guid>> keySelection = T.PrimaryKey;
            ParameterExpression param = Expression.Parameter(typeof(T), "e");

            Expression key = new ReplaceParamVisitor(keySelection.Parameters[0], param).Visit(keySelection.Body)!;

            BinaryExpression expression = Expression.Equal(key, Expression.Constant(id));

            Expression body = includeDeleted ? expression : 
                Expression.AndAlso(expression, Expression.Equal(Expression.Property(param, nameof(IIsDeleted.IsDeleted)),Expression.Constant(false)));

            return Expression.Lambda<Func<T, bool>>(body, param);
        }

        public static Task<T?> Get<T>(this DbContext db,
            Guid id,
             bool excludeSoftDelete,
            CancellationToken cancellationToken = default) 
            where T : class, IPrimaryKeySelector<T>, IIsDeleted
        {
            IQueryable<T> query = db.Set<T>().AsQueryable();
            if (!excludeSoftDelete)
                query = query.IgnoreQueryFilters();

            Expression<Func<T, bool>> pred = BuildKeyPredicate<T>(id, includeDeleted: !excludeSoftDelete);
            return query.SingleOrDefaultAsync(pred, cancellationToken);
        }

        public static Task<List<T>> GetFor<T>(
            this DbContext db,
            Guid foreignKey,
            string propertyName,
            bool excludeSoftDelete,
            CancellationToken ct = default)
         where T : class, IPrimaryKeySelector<T>, IIsDeleted
        {
            if (foreignKey == Guid.Empty)
                return Task.FromResult(new List<T>());

            IEntityType? entityType = db.Model.FindEntityType(typeof(T));

            if (entityType == null)
                return default;

            IProperty? prop = entityType.GetProperties()
                         .FirstOrDefault(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));

            if (prop == null)
                return default;

            IQueryable<T> query = db.Set<T>();
            if (!excludeSoftDelete)
                query = query.IgnoreQueryFilters();

            if (prop.ClrType == typeof(Guid))
            {
                return query.Where(e =>
                        EF.Property<Guid>(e, prop.Name) == foreignKey &&
                        (excludeSoftDelete ? !e.IsDeleted : true))
                    .ToListAsync(ct);
            }

            return default;
        }

        public static Task<List<T>> GetFor<T>(
          this DbContext db,
          Guid foreignKey,
          Expression<Func<T, Guid?>> property,
          bool excludeSoftDelete,
          CancellationToken cancellationToken = default)
          where T : class,  IIsDeleted
        {
            if (foreignKey == Guid.Empty)
                return Task.FromResult(new List<T>());


            IQueryable<T> query = db.Set<T>();
            if (!excludeSoftDelete) query = query.IgnoreQueryFilters();

            ParameterExpression prop = property.Parameters[0];
            BinaryExpression expression = Expression.Equal(property.Body, Expression.Convert(Expression.Constant(foreignKey), typeof(Guid?)));

            BinaryExpression body = excludeSoftDelete ?
                Expression.AndAlso(expression, Expression.Equal(Expression.Property(prop, nameof(IIsDeleted.IsDeleted)), Expression.Constant(false))) : expression;

            Expression<Func<T, bool>> pred = Expression.Lambda<Func<T, bool>>(body, prop);

            return query.Where(pred).ToListAsync(cancellationToken);
        }

        public static async Task<T> Upsert<T>(
             this DbContext db,
             T incoming,
             CancellationToken cancellationToken = default)
             where T : class, IPrimaryKeySelector<T>, IIsDeleted
        {
            DbSet<T> set = db.Set<T>();
            Guid key = KeyCache<T>.Get(incoming);

            if (key == Guid.Empty)
            {
                await set.AddAsync(incoming, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return incoming;
            }

            Expression<Func<T, bool>> pred = BuildKeyPredicate<T>(key, includeDeleted: false);
            T? existingRecord = await set.IgnoreQueryFilters().SingleOrDefaultAsync(pred, cancellationToken);
              
            if (existingRecord is null)
            {
                //INSERT NEW
                await set.AddAsync(incoming, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return incoming;
            } else
            {  
                // UPDATE
                EntityEntry<T> entry = db.Entry(existingRecord);
                entry.CurrentValues.SetValues(incoming);
                await db.SaveChangesAsync(cancellationToken);
                return existingRecord; 
            }

          
        }

        //Not a real delete. sets isDeleted = true
        public static async Task<bool> Delete<T>(
            this DbContext db,
            Guid id,
            CancellationToken cancellationToken = default)
            where T : class, IPrimaryKeySelector<T>, IIsDeleted
        {
            DbSet<T> set = db.Set<T>();
            Expression<Func<T, bool>> pred = BuildKeyPredicate<T>(id, includeDeleted: true);
            T? entity = await set.IgnoreQueryFilters().SingleOrDefaultAsync(pred, cancellationToken);
            
            if (entity is null) return false;

            if (entity.IsDeleted) return true;

            entity.IsDeleted = true;
             
            await db.SaveChangesAsync(cancellationToken);
            return true;
        }

    }
}
