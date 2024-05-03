using AutoMapper;
using FitFriends.Logic.Models;
using FitFriends.Logic.Stores;
using FitFriends.Persistence.Entities;

namespace FitFriends.Persistence.Repositories
{
    public class UserRepository() : IUserStore
    {
        public async Task AddAsync(User user)
        {
            UserEntity userEntity = new()
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email
            };



            //await context.Users.AddAsync(userEntity);
            //await context.SaveChangesAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            //UserEntity userEntity = context.Users
            //    .AsNoTracking()
            //    .FirstOrDefaultAsync(us => u.Email == email);

            //return mapper.Map<User>(userEntity);

            var user = User.Create(Guid.NewGuid(), "string", "$2a$11$Qo6efHUzHE4d59NAykyETebLzFGA/Kl4V2plAVRfWeGiaeVmoUpXe", "string");

            return user;
        }
    }
}
