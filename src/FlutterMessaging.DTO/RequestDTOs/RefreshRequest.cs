namespace FlutterMessaging.DTO.RequestDTOs
{
    public class RefreshRequest
    {
        public Guid SessionId { get; set; }
        public string RefreshToken { get; set; }
    }
}
