using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;

namespace FlutterMessaging.DTO.DTOAdapters.Interfaces
{
    public interface IFlashCardSetTemplateItemOptionDtoAdapter
        : IDtoLogicAdapter<FlashCardSetTemplateItemOptionRequest, FlashCardSetTemplateItemOptionResponse>
    {
    }
}
