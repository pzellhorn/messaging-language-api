using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.RequestDTOs.EntityRequests;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.State.Data.Entities;
using pzellhorn.Core.Logic.Base;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class DeviceMapper
        : IDTOMapper<Device, DeviceRequest, DeviceResponse>
    {
        public Guid? ExtractId(DeviceRequest request) => request.DeviceInstallationId;

        public void ApplyRequestToModel(DeviceRequest request, Device model)
        { 
            model.InstallationId = request.DeviceId;
            model.NotificationPushToken = request.NotificationPushToken;
            model.DeviceModel = (request.DeviceModel ?? string.Empty).Trim();
            model.TimeZone = (request.TimeZone ?? string.Empty).Trim(); 
        }

        public Device CreateEntity(DeviceRequest request)
        => new()
        { 
            InstallationId = request.DeviceId,
            NotificationPushToken = request.NotificationPushToken,
            DeviceModel = (request.DeviceModel ?? string.Empty).Trim(),
            TimeZone = (request.TimeZone ?? string.Empty).Trim(),
        };

        public DeviceResponse ToResponse(Device model)
        => new(model.DeviceId, model.ProfileId, model.InstallationId, model.NotificationPushToken, model.DeviceModel, model.TimeZone);
    }
}
