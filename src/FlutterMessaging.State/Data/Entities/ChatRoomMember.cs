using System.Linq.Expressions;
using FlutterMessaging.State.Base;
using FlutterMessaging.State.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlutterMessaging.State.Data.Entities;

public partial class ChatRoomMember : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<ChatRoomMember> 
{
    public Guid ChatRoomMemberId { get; set; }

    public Guid ChatRoomId { get; set; }

    public Guid ProfileId { get; set; }



    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }


    public static Expression<Func<ChatRoomMember, Guid>> PrimaryKey => e => e.ChatRoomMemberId;


    public virtual ChatRoom ChatRoom { get; set; }

    public virtual Profile Profile { get; set; }

} 

internal sealed class ChatRoomMemberConfig : BaseConfig<ChatRoomMember>
{
    public override void Configure(EntityTypeBuilder<ChatRoomMember> entity)
    {
        base.Configure(entity);

        entity.ToTable("chat_room_members");

        entity.HasOne(x => x.ChatRoom)
            .WithMany(x => x.ChatRoomMembers)
            .HasForeignKey(x => x.ChatRoomId);

        entity.HasOne(x => x.Profile)
           .WithMany(x => x.ChatRoomMembers)
           .HasForeignKey(x => x.ProfileId);
    }
}