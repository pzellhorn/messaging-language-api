using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.State.Data.Entities;
using pzellhorn.Core.Logic.Base;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class ProfileSettingOptionMapper
        : IDTOMapper<ProfileSettingOption, ProfileSettingOptionRequest, ProfileSettingOptionResponse>
    {
        public Guid? ExtractId(ProfileSettingOptionRequest request) => request.ProfileSettingOptionId;

        public void ApplyRequestToModel(ProfileSettingOptionRequest request, ProfileSettingOption model)
        {
            model.ProfileSettingId = request.ProfileSettingId; model.OptionKey = (request.OptionKey ?? string.Empty).Trim(); model.OptionValue = (request.OptionValue ?? string.Empty).Trim();
        }

        public ProfileSettingOption CreateEntity(ProfileSettingOptionRequest request)
        => new()
        {
                ProfileSettingId = request.ProfileSettingId, OptionKey = (request.OptionKey ?? string.Empty).Trim(), OptionValue = (request.OptionValue ?? string.Empty).Trim(),
        };

        public ProfileSettingOptionResponse ToResponse(ProfileSettingOption model)
        => new(model.ProfileSettingOptionId, model.ProfileSettingId, model.OptionKey, model.OptionValue);
    }
}
