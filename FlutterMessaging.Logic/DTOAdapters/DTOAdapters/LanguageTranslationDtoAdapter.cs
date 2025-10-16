using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

using FlutterMessaging.DTO.DTOAdapters.Interfaces;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class LanguageTranslationDtoAdapter(
        LanguageTranslationLogic languageTranslationLogic,
        IDTOMapper<LanguageTranslation, LanguageTranslationRequest, LanguageTranslationResponse> mapper)
        : DtoLogicAdapter<LanguageTranslation, LanguageTranslationRequest, LanguageTranslationResponse>(languageTranslationLogic, mapper),
          ILanguageTranslationDtoAdapter
    {
    }
}
