namespace FlutterMessaging.DTO.ResponseDTOs.EntityResponses
{
    public class DeviceResponse
    {
        public DeviceResponse() { }
        public DeviceResponse(Guid deviceInstallationId, Guid deviceId, Guid profileId, Guid notificationPushToken, string? deviceModel, string? timeZone)
        {
            DeviceInstallationId = deviceInstallationId;
            DeviceId = deviceId;
            ProfileId = profileId; 
            NotificationPushToken = notificationPushToken;
            DeviceModel = deviceModel;
            TimeZone = timeZone;
        }
        public Guid DeviceInstallationId { get; set; }
        public Guid DeviceId { get; set; }
        public Guid ProfileId { get; set; } 
        public Guid NotificationPushToken { get; set; }
        public string? DeviceModel { get; set; }
        public string? TimeZone { get; set; }
    }
}
