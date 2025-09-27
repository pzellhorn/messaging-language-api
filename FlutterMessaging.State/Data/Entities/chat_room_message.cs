using System;
using System.Collections.Generic;

namespace FlutterMessaging.State.Data.Entities;

public partial class chat_room_message
{
    public Guid chat_room_message_id { get; set; }

    public Guid profile_id { get; set; }

    public Guid chat_room_id { get; set; }

    public string message_text { get; set; } = null!;

    public bool is_deleted { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public virtual chat_room chat_room { get; set; } = null!;

    public virtual profile profile { get; set; } = null!;
}
