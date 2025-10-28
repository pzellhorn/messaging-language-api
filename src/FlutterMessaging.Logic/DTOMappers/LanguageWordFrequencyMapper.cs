using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.State.Data.Entities;
using pzellhorn.Core.Logic.Base;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class LanguageWordFrequencyMapper
        : IDTOMapper<LanguageWordFrequency, LanguageWordFrequencyRequest, LanguageWordFrequencyResponse>
    {
        public Guid? ExtractId(LanguageWordFrequencyRequest request) => request.LanguageWordFrequencyId;

        public void ApplyRequestToModel(LanguageWordFrequencyRequest request, LanguageWordFrequency model)
        {
            model.LanguageId = request.LanguageId; model.LanguageTranslationId = request.LanguageTranslationId; model.FrequencyRank = request.FrequencyRank;
        }

        public LanguageWordFrequency CreateEntity(LanguageWordFrequencyRequest request)
        => new()
        {
                LanguageId = request.LanguageId, LanguageTranslationId = request.LanguageTranslationId, FrequencyRank = request.FrequencyRank,
        };

        public LanguageWordFrequencyResponse ToResponse(LanguageWordFrequency model)
        => new(model.LanguageWordFrequencyId, model.LanguageId, model.LanguageTranslationId, model.FrequencyRank);
    }
}
