using System;
using System.Collections.Generic;

namespace FlutterMessaging.State.Data.Entities;

public partial class flash_card_set_template_item
{
    public Guid flash_card_set_template_item_id { get; set; }

    public Guid flash_card_set_template_id { get; set; }

    public string question { get; set; } = null!;

    public bool is_deleted { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public virtual ICollection<flash_card_answer> flash_card_answers { get; set; } = new List<flash_card_answer>();

    public virtual flash_card_set_template flash_card_set_template { get; set; } = null!;
}
