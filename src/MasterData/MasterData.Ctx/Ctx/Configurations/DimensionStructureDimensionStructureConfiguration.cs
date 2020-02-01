namespace DigitalLibrary.MasterData.Ctx.Configurations
{
    using DomainModel;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Utils.Guards;

    public class DimensionStructureDimensionStructureConfiguration : IEntityTypeConfiguration<
        DimensionStructureDimensionStructure>
    {
        public void Configure(EntityTypeBuilder<DimensionStructureDimensionStructure> builder)
        {
            Check.IsNotNull(builder);

            builder.ToTable("dimensionstructure_dimensionstructure");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");

            builder.Property(p => p.ChildDimensionStructureId).HasColumnName("child_dimensionstructure_id");
            builder.Property(p => p.ChildDimensionStructureId).IsRequired();

            builder.Property(p => p.ParentDimensionStructureId).HasColumnName("parent_dimensionstructure_id");
            builder.Property(p => p.ParentDimensionStructureId).IsRequired();

            builder.HasOne(child => child.ChildDimensionStructure)
               .WithMany(children => children.ChildDimensionStructures)
               .HasForeignKey(p => p.ChildDimensionStructureId)
               .IsRequired(false);

            builder.HasOne(parent => parent.ParentDimensionStructure)
               .WithMany(parents => parents.ParentDimensionStructures)
               .HasForeignKey(key => key.ParentDimensionStructureId)
               .IsRequired(false);
        }
    }
}