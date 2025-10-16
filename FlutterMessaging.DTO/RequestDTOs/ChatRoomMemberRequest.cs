namespace FlutterMessaging.DTO.RequestDTOs
{ 
    public class ChatRoomMemberRequest
    {
        public ChatRoomMemberRequest() { }
        public ChatRoomMemberRequest(Guid? chatRoomMemberId, Guid chatRoomId, Guid profileId)
        {
            this.ChatRoomMemberId = chatRoomMemberId;
            this.ChatRoomId = chatRoomId;
            this.ProfileId = profileId;
        }
        public Guid? ChatRoomMemberId { get; }
        public Guid ChatRoomId { get; }
        public Guid ProfileId { get; }
    }
}
