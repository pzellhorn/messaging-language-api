using System;
using System.Collections.Generic;

namespace FlutterMessaging.State.Data.Entities;

public partial class profile_setting_option
{
    public Guid profile_setting_option_id { get; set; }

    public Guid profile_settings_id { get; set; }

    public string option_key { get; set; } = null!;

    public string option_value { get; set; } = null!;

    public bool is_deleted { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public virtual profile_setting profile_settings { get; set; } = null!;
}
