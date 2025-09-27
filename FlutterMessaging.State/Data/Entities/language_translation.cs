using System;
using System.Collections.Generic;

namespace FlutterMessaging.State.Data.Entities;

public partial class language_translation
{
    public Guid language_translation_id { get; set; }

    public Guid from_language_id { get; set; }

    public Guid to_language_id { get; set; }

    public string from_language_text { get; set; } = null!;

    public string to_language_text { get; set; } = null!;

    public bool is_deleted { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public virtual ICollection<language_word_frequency> language_word_frequencies { get; set; } = new List<language_word_frequency>();
}
