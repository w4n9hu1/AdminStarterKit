namespace AdminStarterKit.Domain
{
    public interface IUserRepository
    {
        User Find(string email, string password);
    }
}
