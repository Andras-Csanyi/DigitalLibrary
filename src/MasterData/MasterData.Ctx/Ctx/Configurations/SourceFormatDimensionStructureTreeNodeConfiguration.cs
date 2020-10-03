namespace DigitalLibrary.MasterData.Ctx.Configurations
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SourceFormatDimensionStructureTreeNodeConfiguration
        : IEntityTypeConfiguration<SourceFormatDimensionStructure>
    {
        public void Configure(EntityTypeBuilder<SourceFormatDimensionStructure> builder)
        {
            Check.IsNotNull(builder);

            builder.ToTable("sourceformat_dimensionstructure");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");

            builder.Property(p => p.SourceFormatId).HasColumnName("sourceformat_id");

            builder.Property(p => p.DimensionStructureId).HasColumnName("dimensionstructure_id");

            builder.HasOne(p => p.SourceFormat)
               .WithOne(p => p.SourceFormatDimensionStructure)
               .HasForeignKey<SourceFormatDimensionStructure>(k => k.SourceFormatId);

            builder.HasOne(p => p.DimensionStructure)
               .WithOne(p => p.SourceFormatDimensionStructure)
               .HasForeignKey<SourceFormatDimensionStructure>(k => k.DimensionStructureId);
        }
    }
}