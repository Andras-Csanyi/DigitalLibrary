// <copyright file="DimensionDimensionValueConfiguration.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Ctx.Configurations
{
    using DigitalLibrary.MasterData.DomainModel;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DimensionDimensionValueConfiguration : IEntityTypeConfiguration<DimensionDimensionValue>
    {
        public void Configure(EntityTypeBuilder<DimensionDimensionValue> builder)
        {
            builder.ToTable("dimension_dimension_value");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.DimensionId).HasColumnName("dimension_id");
            builder.Property(p => p.DimensionValueId).HasColumnName("dimension_value_id");

            builder.HasOne(p => p.Dimension)
               .WithMany(m => m.DimensionDimensionValues)
               .HasForeignKey(f => f.DimensionId)
               .IsRequired(false);
            builder.HasOne(p => p.DimensionValue)
               .WithMany(m => m.DimensionDimensionValues)
               .HasForeignKey(f => f.DimensionValueId)
               .IsRequired(false);
        }
    }
}