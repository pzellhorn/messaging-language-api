using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

using FlutterMessaging.DTO.DTOAdapters.Interfaces;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class LanguageDtoAdapter(
        LanguageLogic languageLogic,
        IDTOMapper<Language, LanguageRequest, LanguageResponse> mapper)
        : DtoLogicAdapter<Language, LanguageRequest, LanguageResponse>(languageLogic, mapper),
          ILanguageDtoAdapter
    {
    }
}
