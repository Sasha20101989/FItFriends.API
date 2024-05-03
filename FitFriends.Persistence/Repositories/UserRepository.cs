using AutoMapper;
using FitFriends.Logic.Enums;
using FitFriends.Logic.Models;
using FitFriends.Logic.Stores;
using FitFriends.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitFriends.Persistence.Repositories
{
    public class UserRepository(FitFriendsDbContext context, IMapper mapper) : IUserStore
    {
        public async Task AddAsync(User user)
        {
            RoleEntity userRoleEntity = await context.Roles
                .SingleOrDefaultAsync(r => r.Id == (int)Role.User) 
                ?? throw new InvalidOperationException();

            UserEntity userEntity = new()
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
                Roles = [userRoleEntity]
            };

            await context.Users.AddAsync(userEntity);
            await context.SaveChangesAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            UserEntity? userEntity = await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception($"User with email {email} not found.");

            return mapper.Map<User>(userEntity);
        }

        public async Task<HashSet<Permission>> GetUserPermissionsAsync(Guid userId)
        {
            ICollection<RoleEntity>[] roles = await context.Users
                .AsNoTracking()
                .Include(u => u.Roles)
                .ThenInclude(u => u.Permissions)
                .Where(u => u.Id == userId)
                .Select(u => u.Roles)
                .ToArrayAsync();

            return roles
                .SelectMany(r => r)
                .SelectMany(r => r.Permissions)
                .Select(p => (Permission)p.Id)
                .ToHashSet();
        }
    }
}
