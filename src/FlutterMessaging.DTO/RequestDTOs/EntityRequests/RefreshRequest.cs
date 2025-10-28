namespace FlutterMessaging.DTO.RequestDTOs.EntityDTOs
{
    public class RefreshRequest
    {
        public Guid SessionId { get; set; }
        public string RefreshToken { get; set; }
    }
}
