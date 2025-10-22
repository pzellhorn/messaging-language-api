using FlutterMessaging.API.Controllers.Base;
using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace FlutterMessaging.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguageTranslationController(ILanguageTranslationDtoAdapter logic) : BaseController<LanguageTranslationRequest, LanguageTranslationResponse>(logic)
    {
    }
}
