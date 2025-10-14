using System;

namespace FlutterMessaging.DTO.RequestDTOs;

public class ExternalIdentityRequest(Guid? externalIdentityId, Guid profileId, string provider, string subject, string issuer)
{
    public Guid? ExternalIdentityId { get; } = externalIdentityId;
    public Guid ProfileId { get; } = profileId;
    public string Provider { get; } = provider;
    public string Subject { get; } = subject;
    public string Issuer { get; } = issuer;
}
