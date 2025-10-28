using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using pzellhorn.Core.Logic.Base;
using pzellhorn.Core.Logic.Base.DTOAdapter;
using FlutterMessaging.Logic.EntityLogic;
using FlutterMessaging.State.Data.Entities;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

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
