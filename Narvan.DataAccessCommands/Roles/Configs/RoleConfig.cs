using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Narvan.Domains.Roles.Entities;

namespace Narvan.DataAccessCommands.Roles.Configs
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(r => r.Title).IsRequired(true).HasMaxLength(100);


            builder.HasMany(r => r.UserRoles).WithOne(r => r.Role).HasForeignKey(r => r.RoleId);
        }
    }
}