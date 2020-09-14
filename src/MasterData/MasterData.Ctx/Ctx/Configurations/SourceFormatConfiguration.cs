// <copyright file="SourceFormatConfiguration.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Ctx.Configurations
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SourceFormatConfiguration : IEntityTypeConfiguration<SourceFormat>
    {
        public void Configure(EntityTypeBuilder<SourceFormat> builder)
        {
            Check.IsNotNull(builder);

            builder.ToTable("source_format");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Id).HasColumnName("id");

            builder.Property(p => p.Guid).HasColumnName("guid");
            builder.Property(p => p.Guid).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Name).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();

            builder.Property(p => p.Desc).HasColumnName("desc");
            builder.Property(p => p.Desc).IsRequired();

            builder.Property(p => p.IsActive).HasColumnName("is_active");
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsActive).HasDefaultValue(1);

            builder.Property(p => p.RootDimensionStructureId).HasColumnName("root_dimensionstructure_id");

            builder.HasOne(p => p.RootDimensionStructure)
               .WithMany(s => s.SourceFormatsRootDimensionStructures)
               .HasForeignKey(k => k.RootDimensionStructureId)
               .IsRequired(false);
        }
    }
}