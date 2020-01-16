using DigitalLibrary.ControlPanel.Ctx.Context.Configurations;
using DigitalLibrary.ControlPanel.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.ControlPanel.Ctx.Context
{
    public class ControlPanelContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }

        public DbSet<Module> Modules { get; set; }

        protected ControlPanelContext()
        {
        }

        public ControlPanelContext(DbContextOptions<ControlPanelContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ModuleConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
        }
    }
}