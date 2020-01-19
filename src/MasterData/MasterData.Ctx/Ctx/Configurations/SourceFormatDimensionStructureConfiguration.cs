namespace DigitalLibrary.MasterData.Ctx.Configurations
{
    using System;

    using DomainModel;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SourceFormatDimensionStructureConfiguration : IEntityTypeConfiguration<SourceFormatDimensionStructure>
    {
        public void Configure(EntityTypeBuilder<SourceFormatDimensionStructure> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("source_format_dimension_structure");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.SourceFormatId).HasColumnName("source_format_id");
            builder.Property(p => p.DimensionStructureId).HasColumnName("dimension_structure_id");

            builder.HasOne(p => p.SourceFormat)
               .WithMany(m => m.ChildDimensionStructures)
               .HasForeignKey(k => k.SourceFormatId);
            builder.HasOne(p => p.DimensionStructure)
               .WithMany(m => m.ParentSourceFormatDimensionStructures)
               .HasForeignKey(k => k.DimensionStructureId);
        }
    }
}