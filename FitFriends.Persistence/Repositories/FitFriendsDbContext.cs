using FitFriends.Persistence.Configurations;
using FitFriends.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FitFriends.Persistence.Repositories
{
    public class FitFriendsDbContext(
        DbContextOptions<FitFriendsDbContext> dbOptions,
        IOptions<AuthorizationOptions> authOptions) : DbContext(dbOptions)
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FitFriendsDbContext).Assembly);

            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));
        }
    }
}
