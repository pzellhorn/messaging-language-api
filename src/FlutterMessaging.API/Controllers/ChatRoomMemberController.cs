using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using pzellhorn.Core;
using Microsoft.AspNetCore.Mvc;

namespace FlutterMessaging.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatRoomMemberController(IChatRoomMemberDtoAdapter logic) : BaseController<ChatRoomMemberRequest, ChatRoomMemberResponse>(logic)
    {
    }
}
