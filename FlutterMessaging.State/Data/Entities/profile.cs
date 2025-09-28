using System.Linq.Expressions;
using FlutterMessaging.State.Base;
using FlutterMessaging.State.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlutterMessaging.State.Data.Entities;

public partial class Profile : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<Profile> 
{
    public Guid ProfileId { get; set; }

    public string ProfileName { get; set; } = string.Empty;


    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }


    public static Expression<Func<Profile, Guid>> PrimaryKey => e => e.ProfileId; 


    public virtual List<ProfileSetting> ProfileSettings { get; set; } = new(); 
    public virtual List<ChatRoomMember> ChatRoomMembers { get; set; } = new(); 
    public virtual List<ChatRoomMessage> ChatRoomMessages { get; set; } = new(); 
    public virtual List<FlashCardAnswer> FlashCardAnswers { get; set; } = new();
} 

internal sealed class ProfileConfig : BaseConfig<Profile>
{
    public override void Configure(EntityTypeBuilder<Profile> entity)
    {
        base.Configure(entity);

        entity.ToTable("profiles");

        entity.HasMany(x => x.ProfileSettings)
           .WithOne(x => x.Profile)
           .HasForeignKey(x => x.ProfileId);

        entity.HasMany(x => x.ChatRoomMembers)
            .WithOne(x => x.Profile)
            .HasForeignKey(x => x.ProfileId);

        entity.HasMany(x => x.ChatRoomMessages)
           .WithOne(x => x.Profile)
           .HasForeignKey(x => x.ProfileId);

        entity.HasMany(x => x.FlashCardAnswers)
           .WithOne(x => x.Profile)
           .HasForeignKey(x => x.ProfileId);


    }
}