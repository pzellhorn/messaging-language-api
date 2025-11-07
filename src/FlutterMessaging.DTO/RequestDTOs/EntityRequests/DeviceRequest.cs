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
        public DeviceRequest(Guid? deviceInstallationId,  Guid deviceId, string notificationPushToken, string? deviceModel, string? timeZone)
        {
            DeviceInstallationId = deviceInstallationId; 
            DeviceId = deviceId;
            NotificationPushToken = notificationPushToken;
            DeviceModel = deviceModel;
            TimeZone = timeZone;
        }
        public Guid? DeviceInstallationId { get; set; } 
        public Guid DeviceId { get; set; }
        public string NotificationPushToken { get; set; }
        public string? DeviceModel { get; set; }
        public string? TimeZone { get; set; } 
    }
} 