using System.Linq.Expressions;
using pzellhorn.Core.State.Base;
using pzellhorn.Core.State.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlutterMessaging.State.Data.Entities;

public class RefreshToken : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<RefreshToken>
{
    public Guid RefreshTokenId { get; set; }

    public Guid SessionId { get; set; }
    public Session Session { get; set; } 
    public string TokenHash { get; set; } 
    public string TokenSalt { get; set; }  

    public DateTime ExpiresAt { get; set; }
    public DateTime? RevokedAt { get; set; }    
    public Guid? ReplacedById { get; set; }             

    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsDeleted { get; set; }

    public static Expression<Func<RefreshToken, Guid>> PrimaryKey => e => e.RefreshTokenId;
    public virtual RefreshToken? ReplacedBy { get; set; }
}

internal sealed class RefreshTokenConfig : BaseConfig<RefreshToken>
{
    public override void Configure(EntityTypeBuilder<RefreshToken> entity)
    {
        base.Configure(entity);

        entity.ToTable("refresh_tokens");

        entity.HasKey(x => x.RefreshTokenId);

        entity.HasOne(x => x.Session)
              .WithMany(x => x.RefreshTokens)
              .HasForeignKey(x => x.SessionId);
    }
}
