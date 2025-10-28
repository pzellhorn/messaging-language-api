using pzellhorn.Core.Logic.Base;
using FlutterMessaging.State.Data.Entities;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

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
