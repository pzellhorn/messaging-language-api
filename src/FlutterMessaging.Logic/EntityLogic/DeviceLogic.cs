using pzellhorn.Core.Logic.Base;
using pzellhorn.Core.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;
using FlutterMessaging.DTO.RequestDTOs.EntityRequests;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.Logic.EntityLogic
{ 
    public class DeviceLogic(IBaseRepository<DeviceInstallation> deviceRepository) : BaseLogic<DeviceInstallation>(deviceRepository)
    {
        public async Task<DeviceResponse> RegisterDevice(Guid profileId, DeviceRequest request, CancellationToken cancellationToken)
        {   
            List<DeviceInstallation> existingDevices = await deviceRepository.GetFor(profileId, x => x.ProfileId, cancellationToken);
            DeviceInstallation? existingDevice = existingDevices.Where(x => x.DeviceId == request.DeviceId).FirstOrDefault();

            if (existingDevice == null)
            {
                existingDevice = new DeviceInstallation
                {
                    ProfileId = profileId,
                    DeviceId = request.DeviceId,
                    NotificationPushToken = request.NotificationPushToken,
                    DeviceModel = request.DeviceModel,
                    TimeZone = request.TimeZone,
                };  
            } else
            {
                existingDevice.NotificationPushToken = request.NotificationPushToken; 
            }

            existingDevice = await deviceRepository.Upsert(existingDevice, cancellationToken);

            DeviceResponse response = new() 
            {
                DeviceInstallationId = existingDevice.DeviceInstallationId,
                DeviceId = existingDevice.DeviceId,
                ProfileId = profileId, 
                NotificationPushToken = request.NotificationPushToken,
                DeviceModel = request.DeviceModel,
                TimeZone = request.TimeZone,            
            };

            return response;
        }
    }
}
 