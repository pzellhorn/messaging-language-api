using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using pzellhorn.Core.Logic.Base;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class FlashCardSetTemplateMapper
        : IDTOMapper<FlashCardSetTemplate, FlashCardSetTemplateRequest, FlashCardSetTemplateResponse>
    {
        public Guid? ExtractId(FlashCardSetTemplateRequest request) => request.FlashCardSetTemplateId;

        public void ApplyRequestToModel(FlashCardSetTemplateRequest request, FlashCardSetTemplate model)
        {
            model.FlashCardSetName = (request.FlashCardSetName ?? string.Empty).Trim();
            model.FlashCardType = request.FlashCardType;
        }

        public FlashCardSetTemplate CreateEntity(FlashCardSetTemplateRequest request)
        => new()
        {
                FlashCardSetName = (request.FlashCardSetName ?? string.Empty).Trim(),
                FlashCardType = request.FlashCardType,
        };

        public FlashCardSetTemplateResponse ToResponse(FlashCardSetTemplate model)
        => new(model.FlashCardSetTemplateId, model.FlashCardSetName, model.FlashCardType);
    }
}
