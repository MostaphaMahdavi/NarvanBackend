using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Narvan.Domains.ProductVisits.Entities;

namespace Narvan.DataAccessCommands.ProductVisits.Configs
{
    public class ProductVisitConfig:IEntityTypeConfiguration<ProductVisit>
    {
        public void Configure(EntityTypeBuilder<ProductVisit> builder)
        {
            builder.HasKey(pv => pv.Id);
            builder.Property(pv => pv.UserIp).IsRequired(true);


            builder.HasOne(pv => pv.Product).WithMany(pv => pv.ProductVisits).HasForeignKey(pv => pv.ProductId);
        }
    }
}