using System;

namespace FlutterMessaging.DTO.RequestDTOs;

public class SessionRequest(Guid? sessionId, Guid profileId, string? deviceInfo, string? userAgent, string? ipAddress, DateTime? revokedAt)
{
    public Guid? SessionId { get; } = sessionId;
    public Guid ProfileId { get; } = profileId;
    public string? DeviceInfo { get; } = deviceInfo;
    public string? UserAgent { get; } = userAgent;
    public string? IpAddress { get; } = ipAddress;
    public DateTime? RevokedAt { get; } = revokedAt;
}
