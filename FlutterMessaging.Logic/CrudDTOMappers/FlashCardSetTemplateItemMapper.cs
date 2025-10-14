using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.CrudDTOMappers
{
    public class FlashCardSetTemplateItemMapper
        : IDTOMapper<FlashCardSetTemplateItem,FlashCardSetTemplateItemRequest,FlashCardSetTemplateItemResponse>
    {
        public Guid? ExtractId(FlashCardSetTemplateItemRequest request) => request.FlashCardSetTemplateItemId;

        public void ApplyRequestToModel(FlashCardSetTemplateItemRequest request, FlashCardSetTemplateItem model)
        {
            model.FlashCardSetTemplateId = request.FlashCardSetTemplateId;
            model.Question = (request.Question ?? string.Empty).Trim();
        }

        public FlashCardSetTemplateItem CreateEntity(FlashCardSetTemplateItemRequest request)
            => new()
            { 
                FlashCardSetTemplateId = request.FlashCardSetTemplateId,
                Question = (request.Question ?? string.Empty).Trim(),
            };

        public FlashCardSetTemplateItemResponse ToResponse(FlashCardSetTemplateItem model)
            => new(model.FlashCardSetTemplateItemId, model.FlashCardSetTemplateId, model.Question);
    }

}
