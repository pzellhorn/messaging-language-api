using FlutterMessaging.API.Controllers.Base;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlutterMessaging.API.Controllers
{  
    [ApiController]
    [Route("api/[controller]")]
    public class ChatRoomMessageController(DTOAdapter<ChatRoomMessageRequest, ChatRoomMessageResponse> logic) : BaseController<ChatRoomMessageRequest, ChatRoomMessageResponse>(logic)
    {

    }
}
