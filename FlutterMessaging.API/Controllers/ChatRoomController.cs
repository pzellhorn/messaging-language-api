using FlutterMessaging.API.Controllers.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using Microsoft.AspNetCore.Mvc;

namespace FlutterMessaging.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatRoomController(DTOAdapter<ChatRoomRequest, ChatRoomResponse> logic): BaseController<ChatRoomRequest, ChatRoomResponse>(logic)
    {

    }
}
