namespace AdminStarterKit.Api.Contracts
{
    public class BindRoleToUserRequest
    {
        public int UserId { get; set; }

        public List<int> RoleIds { get; set; }
    }
}
