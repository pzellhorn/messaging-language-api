using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using pzellhorn.Core;
using Microsoft.AspNetCore.Mvc;

namespace FlutterMessaging.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatRoomMessageController(IChatRoomMessageDtoAdapter logic) : BaseController<ChatRoomMessageRequest, ChatRoomMessageResponse>(logic)
    {
    }
}
