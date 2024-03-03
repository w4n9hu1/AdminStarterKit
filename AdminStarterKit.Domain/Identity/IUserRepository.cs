namespace AdminStarterKit.Domain.Identity
{
    public interface IUserRepository
    {
        Task<User> FindByIdAsync(int id);
        Task<User> FindByEmailAsync(string email);
    }
}
