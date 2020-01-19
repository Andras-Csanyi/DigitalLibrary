namespace DigitalLibrary.MasterData.Ctx.Configurations
{
    using DomainModel.DomainModel;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DimensionStructureConfiguration : IEntityTypeConfiguration<DimensionStructure>
    {
        public void Configure(EntityTypeBuilder<DimensionStructure> builder)
        {
            builder.ToTable("dimension_structure");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Desc).HasColumnName("description");
            builder.Property(p => p.IsActive).HasColumnName("is_active");
            builder.Property(p => p.SortOrder).HasColumnName("sort_number");
            builder.Property(p => p.ParentDimensionStructureId).HasColumnName("parent_dimensionstructure_id");
            builder.Property(p => p.DimensionId).HasColumnName("dimension_id");

            builder.HasMany(p => p.ChildDimensionStructures)
               .WithOne(one => one.ParentDimensionStructure)
               .HasForeignKey(fk => fk.ParentDimensionStructureId)
               .IsRequired(false);

            builder.HasOne(p => p.Dimension)
               .WithMany(p => p.DimensionStructure)
               .IsRequired(false);
        }
    }
}