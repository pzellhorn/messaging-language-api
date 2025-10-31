using pzellhorn.Core.Logic.Base;
using pzellhorn.Core.State.Base.Interfaces;
using FlutterMessaging.State.Data.Entities;
using FlutterMessaging.DTO.RequestDTOs.MessagingRequests;
using FlutterMessaging.DTO.ResponseDTOs.MessagingResponses;
using FlutterMessaging.Logic.ServiceLogic;

namespace FlutterMessaging.Logic.EntityLogic
{
    public class LanguageTranslationLogic(IBaseRepository<LanguageTranslation> languageTranslationRepository, ILlmTranslator translator) : BaseLogic<LanguageTranslation>(languageTranslationRepository)
    {
        public async Task<LLMTranslationResponse> GetLLMTranslation(Guid profileId,LLMTranslationRequest request, CancellationToken cancellationToken = default)
        {
            return translator.Translate(request); 
        }
    }
}
