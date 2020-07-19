using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Narvan.Domains.Users.Entities;

namespace Narvan.DataAccessCommands.Users.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).IsRequired(true).HasMaxLength(250);
            builder.Property(u => u.LastName).IsRequired(true).HasMaxLength(250);
            builder.Property(u => u.Address).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.Email).IsRequired(true).HasMaxLength(250);
            builder.Property(u => u.Password).IsRequired(true).HasMaxLength(50);


            builder.HasMany(u => u.UserRoles).WithOne(u => u.User).HasForeignKey(u => u.UserId);

        }
    }
}