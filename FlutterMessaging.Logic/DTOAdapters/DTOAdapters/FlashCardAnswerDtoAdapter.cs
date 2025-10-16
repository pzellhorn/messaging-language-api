using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

using FlutterMessaging.DTO.DTOAdapters.Interfaces;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class FlashCardAnswerDtoAdapter(
        FlashCardAnswerLogic flashCardAnswerLogic,
        IDTOMapper<FlashCardAnswer, FlashCardAnswerRequest, FlashCardAnswerResponse> mapper)
        : DtoLogicAdapter<FlashCardAnswer, FlashCardAnswerRequest, FlashCardAnswerResponse>(flashCardAnswerLogic, mapper),
          IFlashCardAnswerDtoAdapter
    {
    }
}
