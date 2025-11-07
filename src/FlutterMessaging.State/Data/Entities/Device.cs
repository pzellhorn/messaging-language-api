using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pzellhorn.Core.State.Base;
using pzellhorn.Core.State.Base.Interfaces;

namespace FlutterMessaging.State.Data.Entities
{
    public class Device : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<Device>
    {
        public Guid DeviceId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid InstallationId { get; set; }
        public Guid NotificationPushToken { get; set; }
        public string? DeviceModel { get; set; }
        public string? TimeZone { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public static Expression<Func<Device, Guid>> PrimaryKey => e => e.DeviceId;
    }
    internal sealed class DeviceConfig : BaseConfig<Device>
    {
        public override void Configure(EntityTypeBuilder<Device> entity)
        {
            base.Configure(entity);

            entity.ToTable("devices");
        }
    } 
}