using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Narvan.Domains.ProductGalleries.Entities;

namespace Narvan.DataAccessCommands.ProductGalleries.Config
{
    public class ProductGalleryConfig:IEntityTypeConfiguration<ProductGallery>
    {
        public void Configure(EntityTypeBuilder<ProductGallery> builder)
        {
            builder.HasKey(pg => pg.Id);
            builder.Property(pg => pg.ImageName).IsRequired(true);
            builder.Property(pg => pg.ProductId).IsRequired(true);


            builder.HasOne(pg => pg.Product).WithMany(pg => pg.ProductGalleries).HasForeignKey(pf => pf.ProductId);
        }
    }
}