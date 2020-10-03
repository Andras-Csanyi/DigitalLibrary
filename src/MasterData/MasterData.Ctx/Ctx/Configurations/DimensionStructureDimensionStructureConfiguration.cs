namespace DigitalLibrary.MasterData.Ctx.Configurations
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DimensionStructureDimensionStructureConfiguration
        : IEntityTypeConfiguration<DimensionStructureDimensionStructure>
    {
        public void Configure(EntityTypeBuilder<DimensionStructureDimensionStructure> builder)
        {
            Check.IsNotNull(builder);

            builder.ToTable("dimensionstructure_dimensionstructure");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id");

            builder.Property(p => p.ChildDimensionStructureId).HasColumnName("child_id");

            builder.Property(p => p.DimensionStructureId).HasColumnName("dimensionstructure_id");
        }
    }
}