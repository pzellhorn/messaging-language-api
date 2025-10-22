using System.Linq.Expressions;
using pzellhorn.Core.State.Base;
using pzellhorn.Core.State.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlutterMessaging.State.Data.Entities;

public partial class ChatRoomMessage : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<ChatRoomMessage> 
{
    public Guid ChatRoomMessageId { get; set; }

    public Guid ProfileId { get; set; }

    public Guid ChatRoomId { get; set; }

    public string MessageText { get; set; } = string.Empty;


    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }


    public static Expression<Func<ChatRoomMessage, Guid>> PrimaryKey => e => e.ChatRoomId;


    public virtual ChatRoom ChatRoom { get; set; }

    public virtual Profile Profile { get; set; }
}  

internal sealed class ChatRoomMessageConfig : BaseConfig<ChatRoomMessage>
{
    public override void Configure(EntityTypeBuilder<ChatRoomMessage> entity)
    {
        base.Configure(entity);

        entity.ToTable("chat_room_messages");

        entity.HasOne(x => x.ChatRoom)
           .WithMany(x => x.ChatRoomMessages)
           .HasForeignKey(x => x.ChatRoomId);

        entity.HasOne(x => x.Profile)
         .WithMany(x => x.ChatRoomMessages)
         .HasForeignKey(x => x.ProfileId);
    }
}