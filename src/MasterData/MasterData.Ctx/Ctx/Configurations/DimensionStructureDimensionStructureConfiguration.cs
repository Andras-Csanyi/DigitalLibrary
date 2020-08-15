// <copyright file="DimensionStructureDimensionStructureConfiguration.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Ctx.Configurations
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DimensionStructureDimensionStructureConfiguration
        : IEntityTypeConfiguration<
            DimensionStructureDimensionStructure>
    {
        public void Configure(EntityTypeBuilder<DimensionStructureDimensionStructure> builder)
        {
            Check.IsNotNull(builder);

            builder.ToTable("dimensionstructure_dimensionstructure");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");

            builder.Property(p => p.DimensionStructureId).HasColumnName("dimensionstructure_id");

            builder.Property(p => p.ChildDimensionStructureId).HasColumnName("child_dimensionstructure_id");
            builder.Property(p => p.ChildDimensionStructureId).HasDefaultValue(0);

            builder.Property(p => p.ParentDimensionStructureId).HasColumnName("parent_dimensionstructure_id");
            builder.Property(p => p.ParentDimensionStructureId).HasDefaultValue(0);
        }
    }
}