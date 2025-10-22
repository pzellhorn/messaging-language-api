using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.State.Data.Entities;
using pzellhorn.Core.Logic.Base;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class ExternalIdentityMapper
        : IDTOMapper<ExternalIdentity, ExternalIdentityRequest, ExternalIdentityResponse>
    {
        public Guid? ExtractId(ExternalIdentityRequest request) => request.ExternalIdentityId;

        public void ApplyRequestToModel(ExternalIdentityRequest request, ExternalIdentity model)
        {
            model.ProfileId = request.ProfileId;
            model.Provider = (request.Provider ?? string.Empty).Trim();
            model.Subject = (request.Subject ?? string.Empty).Trim();
            model.Issuer = (request.Issuer ?? string.Empty).Trim();
        }

        public ExternalIdentity CreateEntity(ExternalIdentityRequest request)
        => new()
        {
                ProfileId = request.ProfileId,
                Provider = (request.Provider ?? string.Empty).Trim(),
                Subject = (request.Subject ?? string.Empty).Trim(),
                Issuer = (request.Issuer ?? string.Empty).Trim(),
        };

        public ExternalIdentityResponse ToResponse(ExternalIdentity model)
        => new(model.ExternalIdentityId, model.ProfileId, model.Provider, model.Subject, model.Issuer);
    }
}
