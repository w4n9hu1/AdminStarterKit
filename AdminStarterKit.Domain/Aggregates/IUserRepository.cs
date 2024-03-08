namespace AdminStarterKit.Domain.Aggregates
{
    public interface IUserRepository : IRepository<User>
    {
        User Add(User user);

        Task DeleteAsync(int userId);

        void Update(User user);

        Task<User> GetAsync(int userId);

        IEnumerable<User> GetAllAsync();
    }
}
