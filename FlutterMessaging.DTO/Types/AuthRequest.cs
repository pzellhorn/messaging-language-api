namespace FlutterMessaging.DTO.Types
{
    public class AuthRequest
    {
        public string Token { get; set; }
        public string deviceId { get; set; }
        public string? Nonce { get; set; }
    }
}
