using FitFriends.Application.Interfaces;
using FitFriends.Logic.Enums;
using FitFriends.Persistence.Repositories;

namespace FitFriends.Infrastructure.Authentication
{
    public class PermissionService(IUserStore userStore) : IPermissionService
    {
        public async Task<HashSet<Permission>> GetPermissionsAsync(Guid userId)
        {
            return await userStore.GetUserPermissionsAsync(userId);
        }
    }
}
