namespace DigitalLibrary.MasterData.Ctx
{
    using Configurations;

    using DomainModel.DomainModel;

    using Microsoft.EntityFrameworkCore;

    public class MasterDataContext : DbContext
    {
        public DbSet<Dimension> Dimensions { get; set; }

        public DbSet<DimensionValue> DimensionValues { get; set; }

        public DbSet<DimensionDimensionValue> DimensionDimensionValues { get; set; }

        public DbSet<DimensionStructure> DimensionStructures { get; set; }

        public MasterDataContext(DbContextOptions<MasterDataContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DimensionConfiguration());
            modelBuilder.ApplyConfiguration(new DimensionValueConfiguration());
            modelBuilder.ApplyConfiguration(new DimensionDimensionValueConfiguration());
            modelBuilder.ApplyConfiguration(new DimensionStructureConfiguration());
        }
    }
}