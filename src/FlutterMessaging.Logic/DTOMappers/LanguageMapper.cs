using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class LanguageMapper
        : IDTOMapper<Language, LanguageRequest, LanguageResponse>
    {
        public Guid? ExtractId(LanguageRequest request) => request.LanguageId;

        public void ApplyRequestToModel(LanguageRequest request, Language model)
        {
            model.Name = (request.Name ?? string.Empty).Trim();
        }

        public Language CreateEntity(LanguageRequest request)
        => new()
        {
                Name = (request.Name ?? string.Empty).Trim(),
        };

        public LanguageResponse ToResponse(Language model)
        => new(model.LanguageId, model.Name);
    }
}
