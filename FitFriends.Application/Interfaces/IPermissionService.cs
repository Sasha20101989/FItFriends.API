using FitFriends.Logic.Enums;

namespace FitFriends.Application.Interfaces
{
    public interface IPermissionService
    {
        Task<HashSet<Permission>> GetPermissionsAsync(Guid userId);
    }
}