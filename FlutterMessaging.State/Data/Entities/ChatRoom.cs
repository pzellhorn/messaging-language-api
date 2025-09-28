using System.Linq.Expressions;
using FlutterMessaging.State.Base;
using FlutterMessaging.State.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlutterMessaging.State.Data.Entities;

public class ChatRoom : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<ChatRoom>
{
    public Guid ChatRoomId { get; set; }              
    public string Name { get; set; } = string.Empty;   

    public bool IsDeleted { get; set; }        
    public DateTime CreatedAt { get; set; }  
    public DateTime ModifiedAt { get; set; }     

    public List<ChatRoomMember> ChatRoomMembers { get; set; } = new();
    public List<ChatRoomMessage> ChatRoomMessages { get; set; } = new();

    public static Expression<Func<ChatRoom, Guid>> PrimaryKey => e => e.ChatRoomId; 
}

internal sealed class ChatRoomConfig : BaseConfig<ChatRoom>
{
    public override void Configure(EntityTypeBuilder<ChatRoom> entity)
    {
        base.Configure(entity);

        entity.ToTable("chat_rooms");

        entity.HasMany(x => x.ChatRoomMembers)
            .WithOne(x => x.ChatRoom)
            .HasForeignKey(x => x.ChatRoomId);

        entity.HasMany(x => x.ChatRoomMessages)
            .WithOne(x => x.ChatRoom)
            .HasForeignKey(x => x.ChatRoomId);
    }
}