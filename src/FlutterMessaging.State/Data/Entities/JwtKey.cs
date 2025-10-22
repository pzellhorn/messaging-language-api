using System.Linq.Expressions;
using FlutterMessaging.State.Base;
using FlutterMessaging.State.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlutterMessaging.State.Data.Entities;

public class JwtKey : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<JwtKey>
{
    public Guid JwtKeyId { get; set; }
    public string Kid { get; set; }
    public string Alg { get; set; }     
    public string PublicKeyPem { get; set; } 
    public bool IsActive { get; set; }    

    public string? KeyVaultKeyId { get; set; }     //Id stored in keystore - currently planning Azure?

    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsDeleted { get; set; }

    public static Expression<Func<JwtKey, Guid>> PrimaryKey => e => e.JwtKeyId; 
}

internal sealed class JwtKeyConfig : BaseConfig<JwtKey>
{
    public override void Configure(EntityTypeBuilder<JwtKey> entity)
    {
        base.Configure(entity);

        entity.ToTable("jwt_keys");  
    }
}
