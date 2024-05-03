using FitFriends.Logic.Enums;
using FitFriends.Logic.Models;

namespace FitFriends.Persistence.Repositories
{
    public interface IUserStore
    {
        Task AddAsync(User user);

        Task<User> GetByEmailAsync(string email);

        Task<HashSet<Permission>> GetUserPermissionsAsync(Guid userId);
    }
}
