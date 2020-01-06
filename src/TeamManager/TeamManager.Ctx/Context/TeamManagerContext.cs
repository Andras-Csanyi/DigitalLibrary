namespace DigitalLibrary.IaC.TeamManager.Ctx.Context
{
    using Configurations;

    using DomainModel.Entities;

    using Microsoft.EntityFrameworkCore;

    public class TeamManagerContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<People> Peoples { get; set; }

        public DbSet<PeopleEventLog> PeopleEventLogs { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Title> Titles { get; set; }

        public TeamManagerContext(DbContextOptions<TeamManagerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfigurations());
            modelBuilder.ApplyConfiguration(new EventConfigurations());
            modelBuilder.ApplyConfiguration(new PeopleConfigurations());
            modelBuilder.ApplyConfiguration(new PeopleEventLogConfigurations());
            modelBuilder.ApplyConfiguration(new PositionConfigurations());
            modelBuilder.ApplyConfiguration(new TitleConfigurations());
        }
    }
}