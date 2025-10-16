namespace FlutterMessaging.DTO.RequestDTOs;

public class ChatRoomMemberRequest(Guid? chatRoomMemberId, Guid chatRoomId, Guid profileId)
{
    public Guid? ChatRoomMemberId { get; } = chatRoomMemberId;
    public Guid ChatRoomId { get; } = chatRoomId;
    public Guid ProfileId { get; } = profileId;
}
