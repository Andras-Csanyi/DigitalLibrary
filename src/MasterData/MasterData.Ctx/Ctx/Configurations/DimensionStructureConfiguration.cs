namespace DigitalLibrary.MasterData.Ctx.Configurations
{
    using DomainModel;

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
            builder.Property(p => p.Name).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();

            builder.Property(p => p.Desc).HasColumnName("description");
            builder.Property(p => p.Desc).IsRequired();

            builder.Property(p => p.IsActive).HasColumnName("is_active");
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsActive).HasDefaultValue(1);

            builder.Property(p => p.SortOrder).HasColumnName("sort_number");

            builder.Property(p => p.DimensionId).HasColumnName("dimension_id");

            builder.HasOne(p => p.Dimension)
               .WithMany(p => p.DimensionStructure)
               .IsRequired(false);
        }
    }
}