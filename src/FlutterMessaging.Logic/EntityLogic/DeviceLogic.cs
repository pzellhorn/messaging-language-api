using pzellhorn.Core.Logic.Base;
using pzellhorn.Core.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;
using FlutterMessaging.DTO.RequestDTOs.EntityRequests;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.Logic.EntityLogic
{ 
    public class DeviceLogic(IBaseRepository<Device> deviceRepository) : BaseLogic<Device>(deviceRepository)
    {
        public async Task<DeviceResponse> RegisterDevice(Guid profileId, DeviceRequest request, CancellationToken cancellationToken)
        { 
            ArgumentNullException.ThrowIfNullOrEmpty(request.NotificationPushToken.ToString());
            ArgumentNullException.ThrowIfNullOrEmpty(request.DeviceId.ToString());

            DateTime now = DateTime.UtcNow; 

            List<Device> existingDevices = await deviceRepository.GetFor(profileId, x => x.ProfileId, cancellationToken);
            Device? existingDevice = existingDevices.Where(x => x.InstallationId == request.DeviceId).FirstOrDefault();

            if (existingDevice == null)
            {
                existingDevice = new Device
                {
                    ProfileId = profileId,
                    InstallationId = request.DeviceId,
                    NotificationPushToken = request.NotificationPushToken,
                    DeviceModel = request.DeviceModel,
                    TimeZone = request.TimeZone,
                };

                existingDevice = await deviceRepository.Upsert(existingDevice, cancellationToken);
            }

            DeviceResponse response = new() 
            {
                DeviceId = existingDevice.DeviceId,
                ProfileId = profileId,
                InstallationId = request.DeviceId,
                NotificationPushToken = request.NotificationPushToken,
                DeviceModel = request.DeviceModel,
                TimeZone = request.TimeZone,            
            };

            return response;
        }
    }
}
 