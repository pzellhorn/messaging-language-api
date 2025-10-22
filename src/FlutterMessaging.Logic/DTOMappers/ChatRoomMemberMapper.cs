using FlutterMessaging.DTO.RequestDTOs;
using FlutterMessaging.DTO.ResponseDTOs;
using FlutterMessaging.State.Data.Entities;
using pzellhorn.Core.Logic.Base;

namespace FlutterMessaging.Logic.DTOMappers
{
    public class ChatRoomMemberMapper
        : IDTOMapper<ChatRoomMember, ChatRoomMemberRequest, ChatRoomMemberResponse>
    {
        public Guid? ExtractId(ChatRoomMemberRequest request) => request.ChatRoomMemberId;

        public void ApplyRequestToModel(ChatRoomMemberRequest request, ChatRoomMember model)
        {
            model.ChatRoomId = request.ChatRoomId;
            model.ProfileId = request.ProfileId;
        }

        public ChatRoomMember CreateEntity(ChatRoomMemberRequest request)
        => new()
        {
                ChatRoomId = request.ChatRoomId,
                ProfileId = request.ProfileId,
        };

        public ChatRoomMemberResponse ToResponse(ChatRoomMember model)
        => new(model.ChatRoomMemberId, model.ChatRoomId, model.ProfileId);
    }
}
