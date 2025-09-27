using System;
using System.Collections.Generic;

namespace FlutterMessaging.State.Data.Entities;

public partial class profile_setting
{
    public Guid profile_settings_id { get; set; }

    public Guid profile_id { get; set; }

    public bool is_deleted { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public virtual profile profile { get; set; } = null!;

    public virtual ICollection<profile_setting_option> profile_setting_options { get; set; } = new List<profile_setting_option>();
}
