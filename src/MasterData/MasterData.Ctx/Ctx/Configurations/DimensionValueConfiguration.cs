// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.Ctx.Configurations
{
    using DomainModel;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

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