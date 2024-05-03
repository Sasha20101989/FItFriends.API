using FitFriends.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FitFriends.Persistence.Configurations
{
    public class UserRoleConfiguration() : IEntityTypeConfiguration<UserRoleEntity>
    {
        public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });
        }
    }
}
