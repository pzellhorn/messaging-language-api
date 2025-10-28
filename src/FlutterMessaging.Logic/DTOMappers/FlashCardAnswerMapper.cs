using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.State.Data.Entities;
using pzellhorn.Core.Logic.Base;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class FlashCardAnswerMapper
        : IDTOMapper<FlashCardAnswer, FlashCardAnswerRequest, FlashCardAnswerResponse>
    {
        public Guid? ExtractId(FlashCardAnswerRequest request) => request.FlashCardAnswerId;

        public void ApplyRequestToModel(FlashCardAnswerRequest request, FlashCardAnswer model)
        {
            model.FlashCardSetTemplateItemId = request.FlashCardSetTemplateItemId;
            model.ProfileId = request.ProfileId;
            model.Answer = (request.Answer ?? string.Empty).Trim();
        }

        public FlashCardAnswer CreateEntity(FlashCardAnswerRequest request)
        => new()
        {
                FlashCardSetTemplateItemId = request.FlashCardSetTemplateItemId,
                ProfileId = request.ProfileId,
                Answer = (request.Answer ?? string.Empty).Trim(),
        };

        public FlashCardAnswerResponse ToResponse(FlashCardAnswer model)
        => new(model.FlashCardAnswerId, model.FlashCardSetTemplateItemId, model.ProfileId, model.Answer);
    }
}
