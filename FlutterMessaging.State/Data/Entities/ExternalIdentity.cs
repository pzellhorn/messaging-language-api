
using System.Linq.Expressions;
using FlutterMessaging.State.Base;
using FlutterMessaging.State.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlutterMessaging.State.Data.Entities;

public partial class ExternalIdentity : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<ExternalIdentity>
{
    public Guid ExternalIdentityId { get; set; }
    public Guid ProfileId { get; set; }

    public string Provider { get; set; }
    public string Subject { get; set; }
    public string Issuer { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }


    public static Expression<Func<ExternalIdentity, Guid>> PrimaryKey => e => e.ExternalIdentityId;

    public virtual Profile Profile { get; set; }
}

internal sealed class ExternalIdentityConfig : BaseConfig<ExternalIdentity>
{
    public override void Configure(EntityTypeBuilder<ExternalIdentity> entity)
    {
        base.Configure(entity);

        entity.ToTable("external_identities");

        entity.HasOne(x => x.Profile)
         .WithMany(x => x.ExternalIdentities)
         .HasForeignKey(x => x.ProfileId); 
    }
}
