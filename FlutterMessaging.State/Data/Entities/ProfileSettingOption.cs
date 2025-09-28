using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FlutterMessaging.State.Base;
using FlutterMessaging.State.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlutterMessaging.State.Data.Entities;

public partial class ProfileSettingOption : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<ProfileSettingOption> 
{
    public Guid ProfileSettingOptionId { get; set; }

    public Guid ProfileSettingId { get; set; }

    public string OptionKey { get; set; } = null!;

    public string OptionValue { get; set; } = null!;


    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }


    public static Expression<Func<ProfileSettingOption, Guid>> PrimaryKey => e => e.ProfileSettingOptionId; 


    public virtual ProfileSetting ProfileSetting { get; set; } = null!;
} 

internal sealed class ProfileSettingOptionConfig : BaseConfig<ProfileSettingOption>
{
    public override void Configure(EntityTypeBuilder<ProfileSettingOption> entity)
    {
        base.Configure(entity);

        entity.ToTable("profile_setting_options");

        entity.HasOne(x => x.ProfileSetting)
        .WithMany(x => x.ProfileSettingOptions)
        .HasForeignKey(x => x.ProfileSettingId);
    }
}