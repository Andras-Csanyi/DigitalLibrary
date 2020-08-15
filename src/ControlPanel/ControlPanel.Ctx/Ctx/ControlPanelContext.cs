// <copyright file="ControlPanelContext.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.Ctx.Ctx
{
    using Configurations;

    using DomainModel.Entities;

    using Microsoft.EntityFrameworkCore;

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