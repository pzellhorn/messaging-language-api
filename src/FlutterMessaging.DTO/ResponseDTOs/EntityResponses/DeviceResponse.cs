namespace FlutterMessaging.DTO.ResponseDTOs.EntityResponses
{
    public class DeviceResponse
    {
        public DeviceResponse() { }
        public DeviceResponse(Guid deviceId, Guid profileId, Guid installationId, Guid notificationPushToken, string? deviceModel, string? timeZone)
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
