using FlutterMessaging.DTO.DTOAdapters.Interfaces;
using pzellhorn.Core;
using Microsoft.AspNetCore.Mvc;
using FlutterMessaging.DTO.RequestDTOs.EntityDTOs;
using FlutterMessaging.DTO.ResponseDTOs.EntityResponses;

namespace FlutterMessaging.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatRoomMemberController(IChatRoomMemberDtoAdapter logic) : BaseController<ChatRoomMemberRequest, ChatRoomMemberResponse>(logic)
    {
    }
}
