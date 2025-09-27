using System;
using System.Collections.Generic;

namespace FlutterMessaging.State.Data.Entities;

public partial class chat_room
{
    public Guid chat_room_id { get; set; }

    public string chat_room_name { get; set; } = null!;

    public bool is_deleted { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public virtual ICollection<chat_room_member> chat_room_members { get; set; } = new List<chat_room_member>();

    public virtual ICollection<chat_room_message> chat_room_messages { get; set; } = new List<chat_room_message>();
}
