// <copyright file="ControlPanelContext.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.Ctx.Ctx
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.ControlPanel.Ctx.Ctx.Configurations;
    using DigitalLibrary.ControlPanel.DomainModel.Entities;

    using Microsoft.EntityFrameworkCore;

    [ExcludeFromCodeCoverage]
    public class ControlPanelContext : DbContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ControlPanelContext"/> class.
        /// </summary>
        /// <param name="options">
        ///     <see cref="DbContextOptions{TContext}"/>.
        /// </param>
        public ControlPanelContext(DbContextOptions<ControlPanelContext> options)
            : base(options)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ControlPanelContext"/> class.
        /// </summary>
        protected ControlPanelContext()
        {
        }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Module> Modules { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ModuleConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
        }
    }
}