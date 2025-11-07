using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlutterMessaging.DTO.RequestDTOs.EntityRequests
{
    public class DeviceRequest
    {
        public DeviceRequest() { }
        public DeviceRequest(Guid deviceId, Guid profileId, Guid installationId, Guid notificationPushToken, string? deviceModel, string? timeZone)
        {
            DeviceId = deviceId;
            ProfileId = profileId;
            InstallationId = installationId;
            NotificationPushToken = notificationPushToken;
            DeviceModel = deviceModel;
            TimeZone = timeZone;
        }
        public Guid DeviceId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid InstallationId { get; set; }
        public Guid NotificationPushToken { get; set; }
        public string? DeviceModel { get; set; }
        public string? TimeZone { get; set; } 
    }
} 