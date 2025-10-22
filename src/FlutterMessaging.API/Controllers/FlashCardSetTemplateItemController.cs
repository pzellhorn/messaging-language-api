using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;
using pzellhorn.Core;

namespace FlutterMessaging.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlashCardSetTemplateItemController(IFlashCardSetTemplateItemDtoAdapter logic) : BaseController<FlashCardSetTemplateItemRequest, FlashCardSetTemplateItemResponse>(logic)
    {
    }
}
