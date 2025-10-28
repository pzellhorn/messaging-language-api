namespace FlutterMessaging.DTO.RequestDTOs.EntityDTOs
{
    public class SessionRequest
    {
        public SessionRequest() { }
        public SessionRequest(Guid? sessionId, Guid profileId, string? deviceInfo, string? userAgent, string? ipAddress, DateTime? revokedAt)
        {
            SessionId = sessionId;
            ProfileId = profileId;
            DeviceInfo = deviceInfo;
            UserAgent = userAgent;
            IpAddress = ipAddress;
            RevokedAt = revokedAt;
        }
        public Guid? SessionId { get; set; }
        public Guid ProfileId { get; set; }
        public string? DeviceInfo { get; set; }
        public string? UserAgent { get; set; }
        public string? IpAddress { get; set; }
        public DateTime? RevokedAt { get; set; }
    }
}


