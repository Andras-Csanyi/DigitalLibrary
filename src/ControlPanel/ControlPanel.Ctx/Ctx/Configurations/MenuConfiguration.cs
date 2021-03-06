// <copyright file="MenuConfiguration.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.Ctx.Ctx.Configurations
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.ControlPanel.DomainModel.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    [ExcludeFromCodeCoverage]
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.ToTable("menu");

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Description).HasColumnName("description");
            builder.Property(p => p.MenuRoute).HasColumnName("menu_route");
            builder.Property(p => p.IsActive).HasColumnName("is_active");
            builder.Property(p => p.ModuleId).HasColumnName("module_id");
        }
    }
}
