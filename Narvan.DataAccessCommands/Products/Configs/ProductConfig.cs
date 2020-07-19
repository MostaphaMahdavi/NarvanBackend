using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Narvan.Domains.Products.Entities;

namespace Narvan.DataAccessCommands.Products.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Description).IsRequired(true).HasMaxLength(3900);
            builder.Property(p => p.ImageName).IsRequired(true);
            builder.Property(p => p.Price).IsRequired(true);
            builder.Property(p => p.ProductName).IsRequired(true).HasMaxLength(250);
            builder.Property(p => p.ShortDescription).IsRequired(true).HasMaxLength(700);


            builder.HasMany(p => p.ProductVisits).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);
            builder.HasMany(p => p.ProductGalleries).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);
            builder.HasMany(p => p.ProductSelectedCategories).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);



        }
    }
}