using DigitalLibrary.MasterData.DomainModel.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalLibrary.MasterData.Ctx.Ctx.Configurations
{
    public class DimensionValueConfiguration : IEntityTypeConfiguration<DimensionValue>
    {
        public void Configure(EntityTypeBuilder<DimensionValue> builder)
        {
            builder.ToTable("dimension_value");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Value).HasColumnName("value");
        }
    }
}