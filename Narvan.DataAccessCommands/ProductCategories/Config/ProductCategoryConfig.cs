using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Narvan.Domains.ProductCategories.Entities;

namespace Narvan.DataAccessCommands.ProductCategories.Config
{
    public class ProductCategoryConfig:IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).IsRequired(true).HasMaxLength(250);
            builder.Property(c => c.UrlTitle).IsRequired(true).HasMaxLength(250);

            builder.HasMany(c => c.ProductSelectedCategories).WithOne(c => c.ProductCategory)
                .HasForeignKey(c => c.ProductCategoryId);

          

        }
    }
}