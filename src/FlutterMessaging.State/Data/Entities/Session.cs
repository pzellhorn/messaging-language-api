using System.Linq.Expressions;
using pzellhorn.Core.State.Base;
using pzellhorn.Core.State.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlutterMessaging.State.Data.Entities;

public class Session : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<Session>
{
    public Guid SessionId { get; set; }                
    public Guid ProfileId { get; set; }

    public string? DeviceInfo { get; set; }              
    public string? UserAgent { get; set; }
    public string? IpAddress { get; set; }            
    public DateTime? RevokedAt { get; set; } 
    public DateTime? LastSeenAt { get; set; } 
    public string DeviceId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsDeleted { get; set; }

    public static Expression<Func<Session, Guid>> PrimaryKey => e => e.SessionId;
    public Profile Profile { get; set; }
    public List<RefreshToken> RefreshTokens { get; set; } = new();
}

internal sealed class SessionConfig : BaseConfig<Session>
{
    public override void Configure(EntityTypeBuilder<Session> entity)
    {
        base.Configure(entity);

        entity.ToTable("sessions");

        entity.HasKey(x => x.SessionId);

        entity.HasOne(x => x.Profile)
              .WithMany()
              .HasForeignKey(x => x.ProfileId);

        entity.HasMany(x => x.RefreshTokens)
              .WithOne(x => x.Session)
              .HasForeignKey(x => x.SessionId);
    }
}
