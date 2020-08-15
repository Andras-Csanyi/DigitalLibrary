// <copyright file="MasterDataContext.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Ctx
{
    using DigitalLibrary.MasterData.Ctx.Configurations;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public class MasterDataContext : DbContext
    {
        public DbSet<DimensionDimensionValue> DimensionDimensionValues { get; set; }

        public DbSet<Dimension> Dimensions { get; set; }

        public DbSet<DimensionStructureDimensionStructure> DimensionStructureDimensionStructures { get; set; }

        public DbSet<DimensionStructure> DimensionStructures { get; set; }

        public DbSet<DimensionValue> DimensionValues { get; set; }

        public DbSet<SourceFormat> SourceFormats { get; set; }

        public MasterDataContext(DbContextOptions<MasterDataContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Check.IsNotNull(modelBuilder);

            modelBuilder.ApplyConfiguration(new DimensionConfiguration());
            modelBuilder.ApplyConfiguration(new DimensionValueConfiguration());
            modelBuilder.ApplyConfiguration(new DimensionDimensionValueConfiguration());
            modelBuilder.ApplyConfiguration(new DimensionStructureConfiguration());
            modelBuilder.ApplyConfiguration(new SourceFormatConfiguration());
            modelBuilder.ApplyConfiguration(new DimensionStructureDimensionStructureConfiguration());
        }
    }
}