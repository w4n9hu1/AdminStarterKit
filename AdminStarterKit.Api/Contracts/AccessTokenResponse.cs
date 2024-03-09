namespace AdminStarterKit.Api.Contracts
{
    public class AccessTokenResponse
    {
        public required string AccessToken { get; init; }
        public required string RefreshToken { get; init; }
    }
}
