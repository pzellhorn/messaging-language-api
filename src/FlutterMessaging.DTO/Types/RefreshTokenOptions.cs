namespace FlutterMessaging.DTO.Types
{
    public sealed class RefreshTokenOptions
    {
        public int DaysToLive { get; set; } = 30;
        public int IdleTimeoutDays { get; set; } = 0;
        public string Pepper { get; set; } = string.Empty;
        public int TokenSizeBytes { get; set; } = 32;
        public int SaltSizeBytes { get; set; } = 16;
    }
}

