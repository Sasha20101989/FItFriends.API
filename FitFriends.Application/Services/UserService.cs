using FitFriends.Application.Interfaces;
using FitFriends.Application.Interfaces.Auth;
using FitFriends.Infrastructure;
using FitFriends.Logic.Models;
using FitFriends.Logic.Stores;
using FitFriends.Persistence.Repositories;

namespace FitFriends.Application.Services
{
    public class UserService(
        IUserStore userStore, 
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider) : IUserService
    {
        public async Task RegisterAsync(string userName, string email, string password)
        {
            string hashedPassord = passwordHasher.Generate(password);

            User user = User.Create(Guid.NewGuid(), userName, hashedPassord, email);
        
            await userStore.AddAsync(user);
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            User user = await userStore.GetByEmailAsync(email);

            if (user is null)
            {
                throw new Exception($"User with email '{email}' not found.");
            }

            bool result = passwordHasher.Verify(password, user.PasswordHash);

            if (!result)
            {
                throw new Exception($"Failed to login.");
            }

            var token = jwtProvider.GenerateToken(user);

            return token;
        }
    }
}
