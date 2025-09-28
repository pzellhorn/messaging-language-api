using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FlutterMessaging.State.Base;
using FlutterMessaging.State.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlutterMessaging.State.Data.Entities;

public partial class ProfileSetting : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<ProfileSetting> 
{
    public Guid ProfileSettingId { get; set; }

    public Guid ProfileId { get; set; }


    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }


    public static Expression<Func<ProfileSetting, Guid>> PrimaryKey => e => e.ProfileSettingId;
     

    public virtual Profile Profile { get; set; } = null!;

    public virtual List<ProfileSettingOption> ProfileSettingOptions { get; set; } = new();
}
 
internal sealed class ProfileSettingConfig : BaseConfig<ProfileSetting>
{
    public override void Configure(EntityTypeBuilder<ProfileSetting> entity)
    {
        base.Configure(entity);

        entity.ToTable("profile_settings");


        entity.HasOne(x => x.Profile)
           .WithMany(x => x.ProfileSettings)
           .HasForeignKey(x => x.ProfileId);

        entity.HasMany(x => x.ProfileSettingOptions)
          .WithOne(x => x.ProfileSetting)
          .HasForeignKey(x => x.ProfileSettingId);
    }
}