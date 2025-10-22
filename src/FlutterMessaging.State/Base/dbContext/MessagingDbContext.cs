using Microsoft.EntityFrameworkCore;

namespace FlutterMessaging.State.Data;

public partial class MessagingDbContext : DbContext
{
    public MessagingDbContext(DbContextOptions<MessagingDbContext> options)
        : base(options)
    {
    } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");

        //grab & load our entities
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MessagingDbContext).Assembly);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
