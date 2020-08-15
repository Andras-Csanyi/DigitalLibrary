// <copyright file="DimensionValueConfiguration.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Ctx.Configurations
{
    using DigitalLibrary.MasterData.DomainModel;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DimensionValueConfiguration : IEntityTypeConfiguration<DimensionValue>
    {
        public void Configure(EntityTypeBuilder<DimensionValue> builder)
        {
            builder.ToTable("dimension_value");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Value).HasColumnName("value");
        }
    }
}