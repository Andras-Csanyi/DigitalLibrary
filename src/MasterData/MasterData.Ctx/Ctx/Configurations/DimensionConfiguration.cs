// <copyright file="DimensionConfiguration.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Ctx.Configurations
{
    using DigitalLibrary.MasterData.DomainModel;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <inheritdoc />
    public class DimensionConfiguration : IEntityTypeConfiguration<Dimension>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Dimension> builder)
        {
            builder.ToTable("dimension");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Description).HasColumnName("description");
            builder.Property(p => p.IsActive).HasColumnName("is_active");
        }
    }
}