using System;
using System.Collections.Generic;

namespace FlutterMessaging.State.Data.Entities;

public partial class flash_card_answer
{
    public Guid flash_card_answer_id { get; set; }

    public Guid flash_card_set_template_item_id { get; set; }

    public Guid profile_id { get; set; }

    public string answer { get; set; } = null!;

    public bool is_deleted { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public virtual flash_card_set_template_item flash_card_set_template_item { get; set; } = null!;

    public virtual profile profile { get; set; } = null!;
}
