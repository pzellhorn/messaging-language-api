namespace FlutterMessaging.DTO.ResponseDTOs
{
    public class SessionResponse
    {
        public SessionResponse() { }
        public SessionResponse(Guid? sessionId, Guid profileId, string? deviceInfo, string? userAgent, string? ipAddress, DateTime? revokedAt)
        {
            this.SessionId = sessionId;
            this.ProfileId = profileId;
            this.DeviceInfo = deviceInfo;
            this.UserAgent = userAgent;
            this.IpAddress = ipAddress;
            this.RevokedAt = revokedAt;
        }
        public Guid? SessionId { get; }
        public Guid ProfileId { get; }
        public string? DeviceInfo { get; }
        public string? UserAgent { get; }
        public string? IpAddress { get; }
        public DateTime? RevokedAt { get; }
    }
}
