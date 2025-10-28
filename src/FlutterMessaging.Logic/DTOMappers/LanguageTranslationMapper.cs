using pzellhorn.Core.Logic.Base;
using FlutterMessaging.State.Data.Entities;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class LanguageTranslationMapper
        : IDTOMapper<LanguageTranslation, LanguageTranslationRequest, LanguageTranslationResponse>
    {
        public Guid? ExtractId(LanguageTranslationRequest request) => request.LanguageTranslationId;

        public void ApplyRequestToModel(LanguageTranslationRequest request, LanguageTranslation model)
        {
            model.FromLanguageId = request.FromLanguageId; model.ToLanguageId = request.ToLanguageId; model.FromLanguageText = (request.FromLanguageText ?? string.Empty).Trim(); model.ToLanguageText = (request.ToLanguageText ?? string.Empty).Trim();
        }

        public LanguageTranslation CreateEntity(LanguageTranslationRequest request)
        => new()
        {
                FromLanguageId = request.FromLanguageId, ToLanguageId = request.ToLanguageId, FromLanguageText = (request.FromLanguageText ?? string.Empty).Trim(), ToLanguageText = (request.ToLanguageText ?? string.Empty).Trim(),
        };

        public LanguageTranslationResponse ToResponse(LanguageTranslation model)
        => new(model.LanguageTranslationId, model.FromLanguageId, model.ToLanguageId, model.FromLanguageText, model.ToLanguageText);
    }
}
