using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class SessionMapper
        : IDTOMapper<Session, SessionRequest, SessionResponse>
    {
        public Guid? ExtractId(SessionRequest request) => request.SessionId;

        public void ApplyRequestToModel(SessionRequest request, Session model)
        {
            model.ProfileId = request.ProfileId; model.DeviceInfo = (request.DeviceInfo ?? string.Empty).Trim(); model.UserAgent = (request.UserAgent ?? string.Empty).Trim(); model.IpAddress = (request.IpAddress ?? string.Empty).Trim(); model.RevokedAt = request.RevokedAt;
        }

        public Session CreateEntity(SessionRequest request)
        => new()
        {
                ProfileId = request.ProfileId, DeviceInfo = (request.DeviceInfo ?? string.Empty).Trim(), UserAgent = (request.UserAgent ?? string.Empty).Trim(), IpAddress = (request.IpAddress ?? string.Empty).Trim(), RevokedAt = request.RevokedAt,
        };

        public SessionResponse ToResponse(Session model)
        => new(model.SessionId, model.ProfileId, model.DeviceInfo, model.UserAgent, model.IpAddress, model.RevokedAt);
    }
}
