using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using pzellhorn.Core.Logic.Base;
using pzellhorn.Core.Logic.Base.DTOAdapter;
using FlutterMessaging.Logic.EntityLogic;
using FlutterMessaging.State.Data.Entities;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class FlashCardSetTemplateItemDtoAdapter(
        FlashCardSetTemplateItemLogic flashCardSetTemplateItemLogic,
        IDTOMapper<FlashCardSetTemplateItem, FlashCardSetTemplateItemRequest, FlashCardSetTemplateItemResponse> mapper)
        : DtoLogicAdapter<FlashCardSetTemplateItem, FlashCardSetTemplateItemRequest, FlashCardSetTemplateItemResponse>(flashCardSetTemplateItemLogic, mapper),
          IFlashCardSetTemplateItemDtoAdapter
    {
    }
}
