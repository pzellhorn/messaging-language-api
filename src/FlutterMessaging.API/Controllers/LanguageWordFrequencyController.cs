using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;
using Microsoft.AspNetCore.Mvc;
using pzellhorn.Core;

namespace FlutterMessaging.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguageWordFrequencyController(ILanguageWordFrequencyDtoAdapter logic) : BaseController<LanguageWordFrequencyRequest, LanguageWordFrequencyResponse>(logic)
    {
    }
}
