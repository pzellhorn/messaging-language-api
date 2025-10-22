using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.State.Data.Entities;
using pzellhorn.Core.Logic.Base;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class ChatRoomMapper
        : IDTOMapper<ChatRoom, ChatRoomRequest, ChatRoomResponse>
    {
        public Guid? ExtractId(ChatRoomRequest request) => request.ChatRoomId;

        public void ApplyRequestToModel(ChatRoomRequest request, ChatRoom model)
        {
            model.Name = (request.Name ?? string.Empty).Trim();
        }

        public ChatRoom CreateEntity(ChatRoomRequest request)
        => new()
        {
                Name = (request.Name ?? string.Empty).Trim(),
        };

        public ChatRoomResponse ToResponse(ChatRoom model)
        => new(model.ChatRoomId, model.Name);
    }
}
