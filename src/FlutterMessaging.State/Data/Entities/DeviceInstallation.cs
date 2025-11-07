using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pzellhorn.Core.State.Base;
using pzellhorn.Core.State.Base.Interfaces;

namespace FlutterMessaging.State.Data.Entities
{
    public class DeviceInstallation : IIsDeleted, ICreatedAt, IModifiedAt, IPrimaryKeySelector<DeviceInstallation>
    {
        public Guid DeviceInstallationId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid DeviceId { get; set; }
        public Guid NotificationPushToken { get; set; }
        public string? DeviceModel { get; set; }
        public string? TimeZone { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public static Expression<Func<DeviceInstallation, Guid>> PrimaryKey => e => e.DeviceInstallationId;
    }
    internal sealed class DeviceInstallationConfig : BaseConfig<DeviceInstallation>
    {
        public override void Configure(EntityTypeBuilder<DeviceInstallation> entity)
        {
            base.Configure(entity);

            entity.ToTable("device_installations");
        }
    } 
}