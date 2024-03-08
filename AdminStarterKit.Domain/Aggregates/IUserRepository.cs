namespace AdminStarterKit.Domain.Aggregates
{
    public interface IUserRepository: IRepository<User>
    {
        User Add(User user);

        Task<User> GetAsync(int userId);
    }
}
