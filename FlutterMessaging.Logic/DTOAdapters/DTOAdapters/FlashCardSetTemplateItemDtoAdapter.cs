using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

using FlutterMessaging.DTO.DTOAdapters.Interfaces;

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
