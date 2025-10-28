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
    public class ChatRoomController(IChatRoomDtoAdapter logic) : BaseController<ChatRoomRequest, ChatRoomResponse>(logic)
    {
        [HttpPost(nameof(OpenChatRoom))]
        public async Task<ActionResult<PostChatRoomsDmStartResponse>> OpenChatRoom(
           [FromBody] OpenChatRoomRequest request,
           CancellationToken cancellationToken = default)
        {
            var res = await logic.OpenChatRoom(request, cancellationToken);
            return Ok(res);
        }

        [HttpGet(nameof(ListChatRooms))]
        public async Task<ActionResult<ListChatRoomsResponse>> ListChatRooms(
            [FromQuery] ListChatRoomsRequest request,
            CancellationToken cancellationToken = default)
        {
            var result = await logic.ListChatRooms(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet(nameof(GetMessagesInRoom))]
        public async Task<ActionResult<ChatRoomMessagesInRoomResponse>> GetMessagesInRoom(
            Guid chatRoomId,
            [FromQuery] ChatRoomMessagesInRoomRequest request,
            CancellationToken cancellationToken = default)
        {
            var result = await logic.GetMessagesInRoom(chatRoomId, request, cancellationToken);
            return Ok(result);
        }

        [HttpPost(nameof(SendMessage))]
        public async Task<ActionResult<SendMessageResponse>> SendMessage(
           Guid chatRoomId,
           [FromBody] SendMessageRequest request,
           CancellationToken cancellationToken = default)
        {
            var result = await logic.SendMessage(chatRoomId, request, cancellationToken);
            return Ok(result);
        }

        [HttpPost(nameof(ReadMessage))]
        public async Task<ActionResult<ReadMessageResponse>> ReadMessage(
          Guid chatRoomId,
          [FromBody] ReadMessageRequest request,
          CancellationToken cancellationToken = default)
        {
            var result = await logic.ReadMessage(chatRoomId, request, cancellationToken);
            return Ok(result);
        }
    }
}
