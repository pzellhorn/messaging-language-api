namespace FlutterMessaging.DTO.ResponseDTOs.EntityResponses
{
    public class AuthTokenResponse
    {
        public Guid SessionId { get; set; }

        public string AccessToken { get; set; } = default!;
        public DateTime AccessTokenExpiresAt { get; set; }

        public string RefreshToken { get; set; } = default!;
        public DateTime RefreshTokenExpiresAt { get; set; }
    }
}
