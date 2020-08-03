﻿namespace DigitalLibrary.MasterData.Ctx
{
    using Configurations;

    using DomainModel;

    using Microsoft.EntityFrameworkCore;

    using Utils.Guards;

    public class MasterDataContext : DbContext
    {
        public DbSet<Dimension> Dimensions { get; set; }

        public DbSet<DimensionValue> DimensionValues { get; set; }

        public DbSet<DimensionDimensionValue> DimensionDimensionValues { get; set; }

        public DbSet<DimensionStructure> DimensionStructures { get; set; }

        public DbSet<SourceFormat> SourceFormats { get; set; }

        public DbSet<DimensionStructureDimensionStructure> DimensionStructureDimensionStructures { get; set; }

        public MasterDataContext(DbContextOptions<MasterDataContext> options) : base(options)
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