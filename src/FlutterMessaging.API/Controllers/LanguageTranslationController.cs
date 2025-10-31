using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.RequestDTOs.MessagingRequests;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using FlutterMessaging.DTO.ResponseDTOs.MessagingResponses;
using Microsoft.AspNetCore.Mvc;
using pzellhorn.Core;

namespace FlutterMessaging.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguageTranslationController(ILanguageTranslationDtoAdapter logic) : BaseController<LanguageTranslationRequest, LanguageTranslationResponse>(logic)
    {
        [HttpPost(nameof(GetLlmTranslation))]
        public async Task<ActionResult<LLMTranslationResponse>> GetLlmTranslation(
          [FromBody] LLMTranslationRequest request,
          CancellationToken cancellationToken = default)
        {
            var res = await logic.GetLLMTranslation(request, cancellationToken);
            return Ok(res);
        }
    }
}
