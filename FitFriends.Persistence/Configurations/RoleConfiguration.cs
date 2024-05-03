using FitFriends.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FitFriends.Logic.Enums;

namespace FitFriends.Persistence.Configurations
{
    public partial class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(u => u.Permissions)
                .WithMany(r => r.Roles)
                .UsingEntity<RolePermissionEntity>(
                l => l.HasOne<PermissionEntity>().WithMany().HasForeignKey(r => r.PermissionId),
                r => r.HasOne<RoleEntity>().WithMany().HasForeignKey(u => u.RoleId));

            var roles = Enum
                .GetValues<Role>()
                .Select(r => new RoleEntity
                {
                    Id = (int)r,
                    Name = r.ToString(),
                });

            builder.HasData(roles);
        }
    }
}
