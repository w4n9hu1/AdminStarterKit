namespace AdminStarterKit.Domain
{
    public interface IUserRepository
    {
        User Find(string username, string password);
    }
}
