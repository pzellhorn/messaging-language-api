namespace FlutterMessaging.DTO.Types
{
    public class JwtOptions
    {
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public int AccessTokenMinutes { get; set; } = 15;
        public int RefreshTokenDays { get; set; } = 31;
        public string ActiveKid { get; set; } = "k1";
    }
}
