using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using pzellhorn.Core.Logic.Base.DTOAdapter;

namespace FlutterMessaging.DTO.DTOAdapters.Interfaces
{
    public interface IFlashCardAnswerDtoAdapter
        : IDtoLogicAdapter<FlashCardAnswerRequest, FlashCardAnswerResponse>
    {
    }
}
