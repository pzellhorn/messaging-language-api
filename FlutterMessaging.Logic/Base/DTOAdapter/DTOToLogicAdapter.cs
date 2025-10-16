using FlutterMessaging.State.Base.Interfaces;

namespace FlutterMessaging.Logic.Base.DTOAdapter
{
    public class DtoLogicAdapter<TEntity, TReq, TRes>(
     IBaseLogic<TEntity> logic,
     IDTOMapper<TEntity, TReq, TRes> mapper)
     : IDtoLogicAdapter<TReq, TRes>
     where TEntity : class, IIsDeleted, IPrimaryKeySelector<TEntity>
    {
        public async Task<TRes?> Get(Guid id, CancellationToken cancellationToken = default)
                => (await logic.Get(id, cancellationToken)) is { } e ? mapper.ToResponse(e) : default;

        public async Task<TRes> Upsert(TReq request, CancellationToken cancellationToken = default)
        {
            TEntity entity;
            Guid? id = mapper.ExtractId(request);

            if (id.HasValue)    //create new or retrieve existing full object
            {
                entity = await logic.Get((Guid)id, cancellationToken) ?? throw new KeyNotFoundException($"Id {id} not found.");
                mapper.ApplyRequestToModel(request, entity); 
            }
            else 
            {
                entity = mapper.CreateEntity(request); 
            } 

            return mapper.ToResponse(await logic.Upsert(entity, cancellationToken));
        }

        public Task<bool> Delete(Guid id, CancellationToken cancellationToken = default) => logic.Delete(id, cancellationToken); 
    }
}
