namespace DigitalLibrary.MasterData.Ctx.Configurations
{
    using System;

    using DomainModel;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Utils.Guards;

    public class SourceFormatConfiguration : IEntityTypeConfiguration<SourceFormat>
    {
        public void Configure(EntityTypeBuilder<SourceFormat> builder)
        {
            Check.IsNotNull(builder);

            builder.ToTable("source_format");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasIndex(p => p.Name).IsUnique();

            builder.Property(p => p.Id).HasColumnName("id");

            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Name).IsRequired();

            builder.Property(p => p.Desc).HasColumnName("desc");
            builder.Property(p => p.Desc).IsRequired();

            builder.Property(p => p.IsActive).HasColumnName("is_active");
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsActive).HasDefaultValue(1);

            builder.Property(p => p.RootDimensionStructureId).HasColumnName("root_dimensionstructure_id");

            builder.HasOne(p => p.RootDimensionStructure)
               .WithMany(s => s.SourceFormats)
               .HasForeignKey(k => k.RootDimensionStructureId)
               .IsRequired(false);
        }
    }
}