using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlutterMessaging.State.Data
{
    public static class BaseCrudLogic
    {

        /*
         *  Builds lambdas to execute against DB.
         *   
         *  To include previously-deleted items, ensure the "excludeSoftDelete" flag is false. 
         *  
         *  The Delete function below will mark an item isDeleted = true, rather than actually delete the item.
         * 
         */

        private static IProperty? TryGetIsDeletedProp(IEntityType entityType) =>
          entityType.GetProperties().FirstOrDefault(p =>
               p.Name.Equals("is_deleted", StringComparison.OrdinalIgnoreCase));


        public static async Task<T?> Get<T>(
              this DbContext db,
              Guid id,
              CancellationToken cancellationToken = default,
              bool excludeSoftDelete = true)
              where T : class
        {
            if (!excludeSoftDelete)
                return await db.Set<T>().FindAsync(new object[] { id }, cancellationToken);

            IEntityType entityType = db.Model.FindEntityType(typeof(T))
                        ?? throw new InvalidOperationException($"EF metadata not found for {typeof(T).Name}");

            IKey pk = entityType.FindPrimaryKey()
                        ?? throw new InvalidOperationException($"No primary key configured for {typeof(T).Name}");

            string keyName = pk.Properties[0].Name;

            IProperty? isDeletedProp = TryGetIsDeletedProp(entityType);

            ParameterExpression param = Expression.Parameter(typeof(T), "x");
            MemberExpression memberPk = Expression.PropertyOrField(param, keyName);
            ConstantExpression idConst = Expression.Constant(id);
            Expression body = Expression.Equal(memberPk, idConst);

            if (isDeletedProp != null)
            {
                MemberExpression memberIsDeleted = Expression.PropertyOrField(param, isDeletedProp.Name);
                BinaryExpression notDeleted = Expression.Equal(memberIsDeleted, Expression.Constant(false));
                body = Expression.AndAlso(body, notDeleted);
            }

            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(body, param);
            return await db.Set<T>().SingleOrDefaultAsync(lambda, cancellationToken);
        }


        public static async Task<List<T>> GetFor<T>(
            this DbContext db,
            Guid foreignKey,
            string propertyName,
            CancellationToken cancellationToken = default,
            bool excludeSoftDelete = true)
            where T : class
        {
            if (foreignKey == Guid.Empty)
                return new();

            IEntityType entityType = db.Model.FindEntityType(typeof(T))
                ?? throw new InvalidOperationException($"EF metadata not found for {typeof(T).Name}");

            IProperty prop = entityType.GetProperties()
                .FirstOrDefault(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase))
                ?? throw new InvalidOperationException($"{typeof(T).Name} does not have a property named '{propertyName}'");

            if (prop.ClrType != typeof(Guid) && prop.ClrType != typeof(Guid?))
                throw new InvalidOperationException($"{typeof(T).Name}.{propertyName} must be a Guid or nullable Guid");

            ParameterExpression param = Expression.Parameter(typeof(T), "x");
            MemberExpression memberFk = Expression.PropertyOrField(param, prop.Name);

            Expression fkConst = memberFk.Type == typeof(Guid)
                ? Expression.Constant(foreignKey, typeof(Guid))
                : Expression.Convert(Expression.Constant(foreignKey, typeof(Guid)), typeof(Guid?));

            Expression body = Expression.Equal(memberFk, fkConst);

            if (excludeSoftDelete)
            {
                IProperty? isDeletedProp = TryGetIsDeletedProp(entityType);
                if (isDeletedProp != null)
                {
                    MemberExpression memberIsDeleted = Expression.PropertyOrField(param, isDeletedProp.Name);
                    BinaryExpression notDeleted = Expression.Equal(memberIsDeleted, Expression.Constant(false));
                    body = Expression.AndAlso(body, notDeleted);
                }
            }

            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(body, param);
            return await db.Set<T>().Where(lambda).ToListAsync(cancellationToken);
        }


        public static async Task<T> Upsert<T>(
             this DbContext db,
             T incoming,
             CancellationToken cancellationToken = default,
             bool excludeSoftDelete = true)
             where T : class
        {
            IEntityType entity = db.Model.FindEntityType(typeof(T))
                ?? throw new InvalidOperationException($"EF metadata not found for {typeof(T).Name}");

            IKey pk = entity.FindPrimaryKey()
                ?? throw new InvalidOperationException($"No primary key configured for {typeof(T).Name}");

            IProperty keyProp = pk.Properties[0];
            string keyName = keyProp.Name;

            object? keyValObj = entity.FindProperty(keyName)!.PropertyInfo!.GetValue(incoming);
            Guid key = keyValObj is Guid g ? g : Guid.Empty;

            IProperty? isDeletedProp = TryGetIsDeletedProp(entity);

            // INSERT 
            T? existing = await db.Set<T>().FindAsync(new object[] { key }, cancellationToken);
            if (existing is null)
            {
                if (excludeSoftDelete && isDeletedProp?.PropertyInfo != null)
                    isDeletedProp.PropertyInfo.SetValue(incoming, false);

                await db.Set<T>().AddAsync(incoming, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);
                return incoming;
            }

            // UPDATE 
            EntityEntry<T> entry = db.Entry(existing);
            EntityEntry<T> incomingEntry = db.Entry(incoming);

            foreach (IProperty prop in entity.GetProperties())
            {
                string name = prop.Name;

                if (name.Equals(keyName, StringComparison.OrdinalIgnoreCase)) continue;

                if (isDeletedProp != null &&
                    name.Equals(isDeletedProp.Name, StringComparison.OrdinalIgnoreCase)) continue;

                if (prop.PropertyInfo == null || prop.IsIndexerProperty()) continue;

                object? newVal = prop.PropertyInfo.GetValue(incoming);
                prop.PropertyInfo.SetValue(existing, newVal);
                entry.Property(name).IsModified = true;
            }

            await db.SaveChangesAsync(cancellationToken);
            return existing;
        }


        //Not a real delete. sets isDeleted = true
        public static async Task<bool> Delete<T>(
            this DbContext db,
            Guid id,
            CancellationToken cancellationToken = default,
            bool excludeSoftDelete = true)
            where T : class
        {
            IEntityType entityType = db.Model.FindEntityType(typeof(T))
                ?? throw new InvalidOperationException($"EF metadata not found for {typeof(T).Name}");
            IKey pk = entityType.FindPrimaryKey()
                ?? throw new InvalidOperationException($"No primary key for {typeof(T).Name}");

            T? entity = await db.Set<T>().FindAsync(new object[] { id }, cancellationToken);
            if (entity is null) return false;

            IProperty isDeletedProp = TryGetIsDeletedProp(entityType)
                ?? throw new InvalidOperationException($"{typeof(T).Name} must have a bool 'IsDeleted' property for soft delete.");

            bool current = (bool)(isDeletedProp.PropertyInfo!.GetValue(entity) ?? false);
            if (!current)
            {
                isDeletedProp.PropertyInfo!.SetValue(entity, true);
                db.Entry(entity).Property(isDeletedProp.Name).IsModified = true;
                await db.SaveChangesAsync(cancellationToken);
            }

            return true;
        }
    }
}
