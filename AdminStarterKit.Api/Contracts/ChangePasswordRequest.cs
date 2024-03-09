namespace AdminStarterKit.Api.Contracts
{
    public class ChangePasswordRequest
    {
        public required int UserId { get; init; }
        public required string OldPassword { get; init; }

        public required string NewPassword { get; init; }
    }
}
