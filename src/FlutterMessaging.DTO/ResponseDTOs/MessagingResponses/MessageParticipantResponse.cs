namespace FlutterMessaging.DTO.ResponseDTOs.MessagingResponses
{
    public class MessageParticipantResponse
    {
        public Guid ProfileId { get; set; }
        public string DisplayName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Email { get; set; }
    }
}
