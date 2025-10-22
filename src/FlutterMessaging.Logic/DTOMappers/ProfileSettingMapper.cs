using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class ProfileSettingMapper
        : IDTOMapper<ProfileSetting, ProfileSettingRequest, ProfileSettingResponse>
    {
        public Guid? ExtractId(ProfileSettingRequest request) => request.ProfileSettingId;

        public void ApplyRequestToModel(ProfileSettingRequest request, ProfileSetting model)
        {
            model.ProfileId = request.ProfileId;
        }

        public ProfileSetting CreateEntity(ProfileSettingRequest request)
        => new()
        {
                ProfileId = request.ProfileId,
        };

        public ProfileSettingResponse ToResponse(ProfileSetting model)
        => new(model.ProfileSettingId, model.ProfileId);
    }
}
