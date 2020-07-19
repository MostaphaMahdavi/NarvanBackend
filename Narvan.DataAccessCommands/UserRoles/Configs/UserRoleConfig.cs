using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Narvan.Domains.UserRoles.Entities;

namespace Narvan.DataAccessCommands.UserRoles.Configs
{
    public class UserRoleConfig:IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(ur => ur.Id);


            builder.HasOne(ur => ur.Role).WithMany(ur => ur.UserRoles).HasForeignKey(ur => ur.RoleId);
            builder.HasOne(ur => ur.User).WithMany(ur => ur.UserRoles).HasForeignKey(ur => ur.UserId);

        }
    }
}