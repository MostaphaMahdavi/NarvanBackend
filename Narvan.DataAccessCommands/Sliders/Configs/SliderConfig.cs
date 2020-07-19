using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Narvan.Domains.Sliders.Entities;

namespace Narvan.DataAccessCommands.Sliders.Configs
{
    public class SliderConfig : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Title).IsRequired(true).HasMaxLength(100);
            builder.Property(s => s.Description).IsRequired(true).HasMaxLength(1000);
            builder.Property(s => s.ImageName).IsRequired(true);
            builder.Property(s => s.Link).HasMaxLength(150);

        }
    }
}