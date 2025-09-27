using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.State.Data.Entities;
using FlutterMessaging.State.Data;

namespace FlutterMessaging.State.StateLogic
{
    public class ProfileRepository(MessagingDbContext db)
    {  
        public Task<profile?> Get(Guid id, CancellationToken cancellationToken = default)
            => db.Get<profile>(id, cancellationToken);          

        public Task<profile> Upsert(profile model, CancellationToken cancellationToken = default)
            => db.Upsert(model, cancellationToken); 

        public Task<bool> Delete(Guid id, CancellationToken cancellationToken = default)
            => db.Delete<profile>(id, cancellationToken); 
    }
}
