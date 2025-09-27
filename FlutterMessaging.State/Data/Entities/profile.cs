using System;
using System.Collections.Generic;

namespace FlutterMessaging.State.Data.Entities;

public partial class profile
{
    public Guid profile_id { get; set; }

    public string profile_name { get; set; } = string.Empty;

    public bool is_deleted { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }  

    public virtual ICollection<profile_setting> profile_settings { get; set; } = new List<profile_setting>();
}
