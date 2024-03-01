namespace AdminStarterKit.Domain.Shared
{
    public class JwtConfig
    {
        public const string Position = "Jwt";

        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int ExpiryInMinutes { get; set; }
    }
}
