using System;
using System.Collections.Generic;

namespace FlutterMessaging.State.Data.Entities;

public partial class profile
{
    public Guid profile_id { get; set; }

    public string profile_name { get; set; } = null!;

    public bool is_deleted { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public virtual ICollection<chat_room_member> chat_room_members { get; set; } = new List<chat_room_member>();

    public virtual ICollection<chat_room_message> chat_room_messages { get; set; } = new List<chat_room_message>();

    public virtual ICollection<flash_card_answer> flash_card_answers { get; set; } = new List<flash_card_answer>();

    public virtual ICollection<profile_setting> profile_settings { get; set; } = new List<profile_setting>();
}
