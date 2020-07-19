using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Narvan.Domains.ProductSelectedCategories.Entities;

namespace Narvan.DataAccessCommands.ProductSelectedCategories.Configs
{
    public class ProductSelectedCategoryConfig:IEntityTypeConfiguration<ProductSelectedCategory>
    {
        public void Configure(EntityTypeBuilder<ProductSelectedCategory> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.ProductId).IsRequired(true);
            builder.Property(s => s.ProductCategoryId).IsRequired(true);


            builder.HasOne(s => s.Product).WithMany(s => s.ProductSelectedCategories).HasForeignKey(s => s.ProductId);
            builder.HasOne(s => s.ProductCategory).WithMany(s => s.ProductSelectedCategories)
                .HasForeignKey(s => s.ProductCategoryId);

        }
    }
}