using System;
using System.Collections.Generic;

namespace FlutterMessaging.State.Data.Entities;

public partial class flash_card_set_template
{
    public Guid flash_card_set_template_id { get; set; }

    public string flash_card_set_name { get; set; } = null!;

    public bool is_deleted { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public virtual ICollection<flash_card_set_template_item> flash_card_set_template_items { get; set; } = new List<flash_card_set_template_item>();
}
