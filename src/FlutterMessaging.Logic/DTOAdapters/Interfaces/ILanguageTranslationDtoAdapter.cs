using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.RequestDTOs.MessagingRequests;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.DTO.ResponseDTOs.MessagingResponses;
using pzellhorn.Core.Logic.Base.DTOAdapter;

namespace FlutterMessaging.DTO.DTOAdapters.Interfaces
{
    public interface ILanguageTranslationDtoAdapter
        : IDtoLogicAdapter<LanguageTranslationRequest, LanguageTranslationResponse>
    {
        public Task<LLMTranslationResponse> GetLLMTranslation(LLMTranslationRequest request, CancellationToken cancellationToken = default);
    }
}
