using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.Logic.Base.DTOAdapter;
using FlutterMessaging.State.Data.Entities;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class ChatRoomMessageMapper
        : IDTOMapper<ChatRoomMessage, ChatRoomMessageRequest, ChatRoomMessageResponse>
    {
        public Guid? ExtractId(ChatRoomMessageRequest request) => request.ChatRoomMessageId;

        public void ApplyRequestToModel(ChatRoomMessageRequest request, ChatRoomMessage model)
        {
            model.ProfileId = request.ProfileId;
            model.ChatRoomId = request.ChatRoomId;
            model.MessageText = (request.MessageText ?? string.Empty).Trim();
        }

        public ChatRoomMessage CreateEntity(ChatRoomMessageRequest request)
        => new()
        {
                ProfileId = request.ProfileId,
                ChatRoomId = request.ChatRoomId,
                MessageText = (request.MessageText ?? string.Empty).Trim(),
        };

        public ChatRoomMessageResponse ToResponse(ChatRoomMessage model)
        => new(model.ChatRoomMessageId, model.ProfileId, model.ChatRoomId, model.MessageText);
    }
}
