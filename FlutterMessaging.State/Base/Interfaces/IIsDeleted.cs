using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.State.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FlutterMessaging.State.Base.Interfaces
{
    public interface IIsDeleted { bool IsDeleted { get; set; } }

}
