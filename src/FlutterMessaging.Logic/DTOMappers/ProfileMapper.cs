using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.State.Data.Entities;
using pzellhorn.Core.Logic.Base;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class ProfileMapper
        : IDTOMapper<Profile, ProfileRequest, ProfileResponse>
    {
        public Guid? ExtractId(ProfileRequest request) => request.ProfileId;

        public void ApplyRequestToModel(ProfileRequest request, Profile model)
        {
            model.ProfileName = (request.ProfileName ?? string.Empty).Trim(); model.EmailAddress = (request.EmailAddress ?? string.Empty).Trim();
        }

        public Profile CreateEntity(ProfileRequest request)
        => new()
        {
                ProfileName = (request.ProfileName ?? string.Empty).Trim(), EmailAddress = (request.EmailAddress ?? string.Empty).Trim(),
        };

        public ProfileResponse ToResponse(Profile model)
        => new(model.ProfileId, model.ProfileName, model.EmailAddress);
    }
}
