namespace FlutterMessaging.DTO.ResponseDTOs.EntityResponses
{
    public class ChatRoomMemberResponse
    {
        public ChatRoomMemberResponse() { }
        public ChatRoomMemberResponse(Guid? chatRoomMemberId, Guid chatRoomId, Guid profileId)
        {
            ChatRoomMemberId = chatRoomMemberId;
            ChatRoomId = chatRoomId;
            ProfileId = profileId;
        }
        public Guid? ChatRoomMemberId { get; set; }
        public Guid ChatRoomId { get; set; }
        public Guid ProfileId { get; set; }
    }
}
