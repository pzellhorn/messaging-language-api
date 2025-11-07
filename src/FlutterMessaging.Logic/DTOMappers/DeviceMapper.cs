using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.RequestDTOs.EntityRequests;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.State.Data.Entities;
using pzellhorn.Core.Logic.Base;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class DeviceMapper
        : IDTOMapper<DeviceInstallation, DeviceRequest, DeviceResponse>
    {
        public Guid? ExtractId(DeviceRequest request) => request.DeviceInstallationId;

        public void ApplyRequestToModel(DeviceRequest request, DeviceInstallation model)
        { 
            model.DeviceId = request.DeviceId;
            model.NotificationPushToken = request.NotificationPushToken;
            model.DeviceModel = (request.DeviceModel ?? string.Empty).Trim();
            model.TimeZone = (request.TimeZone ?? string.Empty).Trim(); 
        }

        public DeviceInstallation CreateEntity(DeviceRequest request)
        => new()
        { 
            DeviceId = request.DeviceId,
            NotificationPushToken = request.NotificationPushToken,
            DeviceModel = (request.DeviceModel ?? string.Empty).Trim(),
            TimeZone = (request.TimeZone ?? string.Empty).Trim(),
        };

        public DeviceResponse ToResponse(DeviceInstallation model)
        => new(model.DeviceInstallationId, model.ProfileId, model.DeviceId, model.NotificationPushToken, model.DeviceModel, model.TimeZone);
    }
}
