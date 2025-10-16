using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class LanguageWordFrequencyDtoAdapter(
        LanguageWordFrequencyLogic languageWordFrequencyLogic,
        IDTOMapper<LanguageWordFrequency, LanguageWordFrequencyRequest, LanguageWordFrequencyResponse> mapper)
        : DtoLogicAdapter<LanguageWordFrequency, LanguageWordFrequencyRequest, LanguageWordFrequencyResponse>(languageWordFrequencyLogic, mapper),
          ILanguageWordFrequencyDtoAdapter
    {
    }
}
