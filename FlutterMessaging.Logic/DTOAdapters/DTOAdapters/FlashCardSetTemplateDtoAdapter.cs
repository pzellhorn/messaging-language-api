using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class FlashCardSetTemplateDtoAdapter(
        FlashCardSetTemplateLogic flashCardSetTemplateLogic,
        IDTOMapper<FlashCardSetTemplate, FlashCardSetTemplateRequest, FlashCardSetTemplateResponse> mapper)
        : DtoLogicAdapter<FlashCardSetTemplate, FlashCardSetTemplateRequest, FlashCardSetTemplateResponse>(flashCardSetTemplateLogic, mapper),
          IFlashCardSetTemplateDtoAdapter
    {
    }
}
