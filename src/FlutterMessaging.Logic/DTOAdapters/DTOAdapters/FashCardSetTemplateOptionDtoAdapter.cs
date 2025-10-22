using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.Logic.EntityLogic;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class FlashCardSetTemplateItemOptionDtoAdapter(
        FlashCardSetTemplateItemOptionLogic FlashCardSetTemplateItemOptionLogic,
        IDTOMapper<FlashCardSetTemplateItemOption, FlashCardSetTemplateItemOptionRequest, FlashCardSetTemplateItemOptionResponse> mapper)
        : DtoLogicAdapter<FlashCardSetTemplateItemOption, FlashCardSetTemplateItemOptionRequest, FlashCardSetTemplateItemOptionResponse>(FlashCardSetTemplateItemOptionLogic, mapper),
          IFlashCardSetTemplateItemOptionDtoAdapter
    {
    }
}
