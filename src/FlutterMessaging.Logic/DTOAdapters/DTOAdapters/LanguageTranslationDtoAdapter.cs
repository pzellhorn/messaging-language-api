using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using pzellhorn.Core.Logic.Base;
using pzellhorn.Core.Logic.Base.DTOAdapter;
using FlutterMessaging.Logic.EntityLogic;
using FlutterMessaging.State.Data.Entities;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.DTO.RequestDTOs.MessagingRequests;
using FlutterMessaging.DTO.ResponseDTOs.MessagingResponses;
using FlutterMessaging.Logic.ServiceLogic;

namespace FlutterMessaging.Logic.DTOAdapters.DTOAdapters
{
    public class LanguageTranslationDtoAdapter(
        LanguageTranslationLogic languageTranslationLogic,
        IUserContext currentUser,
        IDTOMapper<LanguageTranslation, LanguageTranslationRequest, LanguageTranslationResponse> mapper)
        : DtoLogicAdapter<LanguageTranslation, LanguageTranslationRequest, LanguageTranslationResponse>(languageTranslationLogic, mapper),
          ILanguageTranslationDtoAdapter
    {
        public Task<LLMTranslationResponse> GetLLMTranslation(LLMTranslationRequest request, CancellationToken cancellationToken = default)
          => languageTranslationLogic.GetLLMTranslation(currentUser.GetProfileIdOrThrow(), request, cancellationToken);
    }
}
