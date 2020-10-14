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

    /// <summary>
    /// MasterDataContext.
    /// </summary>
    public class MasterDataContext : DbContext
    {
        /// <summary>
        /// Gets or sets DimensionDimensionValues value.
        /// </summary>
        public DbSet<DimensionDimensionValue> DimensionDimensionValues { get; set; }

        /// <summary>
        /// Gets or sets Dimensions value.
        /// </summary>
        public DbSet<Dimension> Dimensions { get; set; }

        /// <summary>
        /// Gets or sets DimensionStructureNodes value.
        /// </summary>
        public DbSet<DimensionStructureNode> DimensionStructureNodes { get; set; }

        /// <summary>
        /// Gets or sets DimensionStructures value.
        /// </summary>
        public DbSet<DimensionStructure> DimensionStructures { get; set; }

        /// <summary>
        /// Gets or sets DimensionValues value.
        /// </summary>
        public DbSet<DimensionValue> DimensionValues { get; set; }

        /// <summary>
        /// Gets or sets SourceFormats value.
        /// </summary>
        public DbSet<SourceFormat> SourceFormats { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterDataContext"/> class.
        /// </summary>
        /// <param name="options">Instance.</param>
        public MasterDataContext(DbContextOptions<MasterDataContext> options)
            : base(options)
        {
        }


        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Check.IsNotNull(modelBuilder);

            modelBuilder.ApplyConfiguration(new DimensionConfiguration());
            modelBuilder.ApplyConfiguration(new DimensionValueConfiguration());
            modelBuilder.ApplyConfiguration(new DimensionDimensionValueConfiguration());
            modelBuilder.ApplyConfiguration(new DimensionStructureConfiguration());
            modelBuilder.ApplyConfiguration(new SourceFormatConfiguration());
            modelBuilder.ApplyConfiguration(new SourceFormatDimensionStructureNodeConfiguration());
            modelBuilder.ApplyConfiguration(new DimensionStructureNodeConfiguration());
        }
    }
}