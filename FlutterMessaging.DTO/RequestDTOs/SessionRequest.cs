namespace FlutterMessaging.DTO.RequestDTOs
{
    public class SessionRequest
    {
        public SessionRequest() { }
        public SessionRequest(Guid? sessionId, Guid profileId, string? deviceInfo, string? userAgent, string? ipAddress, DateTime? revokedAt)
        {
            this.SessionId = sessionId;
            this.ProfileId = profileId;
            this.DeviceInfo = deviceInfo;
            this.UserAgent = userAgent;
            this.IpAddress = ipAddress;
            this.RevokedAt = revokedAt;
        }
        public Guid? SessionId { get; set; }
        public Guid ProfileId { get; set; }
        public string? DeviceInfo { get; set; }
        public string? UserAgent { get; set; }
        public string? IpAddress { get; set; }
        public DateTime? RevokedAt { get; set; }
    }
}


