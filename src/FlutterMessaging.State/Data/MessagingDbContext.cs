using Microsoft.EntityFrameworkCore;
using pzellhorn.Core.State.Base.DBContext;

namespace FlutterMessaging.State.Data
{
    public class MessagingDbContext : BaseDbContext
    {
        public MessagingDbContext(DbContextOptions<MessagingDbContext> options) : base(options) { }
    }

}
