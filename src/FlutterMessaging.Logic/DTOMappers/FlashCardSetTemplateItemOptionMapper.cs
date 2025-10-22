using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.State.Data.Entities;
using pzellhorn.Core.Logic.Base;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class FlashCardSetTemplateItemOptionMapper
        : IDTOMapper<FlashCardSetTemplateItemOption, FlashCardSetTemplateItemOptionRequest, FlashCardSetTemplateItemOptionResponse>
    {
        public Guid? ExtractId(FlashCardSetTemplateItemOptionRequest request) => request.FlashCardSetTemplateItemOptionId;

        public void ApplyRequestToModel(FlashCardSetTemplateItemOptionRequest request, FlashCardSetTemplateItemOption model)
        {
            model.FlashCardSetTemplateItemId = request.FlashCardSetTemplateItemId;
            model.OptionKey = (request.OptionKey ?? string.Empty).Trim();
            model.OptionValue = (request.OptionValue ?? string.Empty).Trim();
        }

        public FlashCardSetTemplateItemOption CreateEntity(FlashCardSetTemplateItemOptionRequest request)
        => new()
        {
                FlashCardSetTemplateItemId = request.FlashCardSetTemplateItemId,
                OptionKey = (request.OptionKey ?? string.Empty).Trim(),
                OptionValue = (request.OptionValue ?? string.Empty).Trim(),
        };

        public FlashCardSetTemplateItemOptionResponse ToResponse(FlashCardSetTemplateItemOption model)
        => new(model.FlashCardSetTemplateItemOptionId, model.FlashCardSetTemplateItemId, model.OptionKey, model.OptionValue);
    }
}
