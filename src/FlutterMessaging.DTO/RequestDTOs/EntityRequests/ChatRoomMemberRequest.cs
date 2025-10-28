namespace FlutterMessaging.DTO.RequestDTOs.EntityDTOs
{
    public class ChatRoomMemberRequest
    {
        public ChatRoomMemberRequest() { }
        public ChatRoomMemberRequest(Guid? chatRoomMemberId, Guid chatRoomId, Guid profileId)
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
