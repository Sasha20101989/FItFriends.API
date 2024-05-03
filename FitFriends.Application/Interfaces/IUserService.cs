namespace FitFriends.Application.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(string userName, string email, string password);

        Task<string> LoginAsync(string email, string password);
    }
}
