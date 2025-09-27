using System;
using System.Collections.Generic;

namespace FlutterMessaging.State.Data.Entities;

public partial class language_word_frequency
{
    public Guid language_word_frequency_id { get; set; }

    public Guid language_id { get; set; }

    public Guid language_translation_id { get; set; }

    public int frequency_rank { get; set; }

    public bool is_deleted { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public virtual language_translation language_translation { get; set; } = null!;
}
