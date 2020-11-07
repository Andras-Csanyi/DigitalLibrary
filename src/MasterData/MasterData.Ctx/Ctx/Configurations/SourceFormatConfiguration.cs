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

    /// <inheritdoc />
    public class SourceFormatConfiguration : IEntityTypeConfiguration<SourceFormat>
    {
        /// <inheritdoc />
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

            builder.HasOne(p => p.SourceFormatDimensionStructureNode)
               .WithOne(s => s.SourceFormat)
               .HasForeignKey<SourceFormatDimensionStructureNode>(k => k.SourceFormatId)
               .IsRequired(false);

            builder.HasMany(m => m.DimensionStructureNodes)
               .WithOne(o => o.SourceFormat)
               .HasForeignKey(k => k.SourceFormatId)
               .IsRequired(false);
        }
    }
}