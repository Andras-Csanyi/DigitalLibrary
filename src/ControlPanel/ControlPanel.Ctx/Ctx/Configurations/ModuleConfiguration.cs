// <copyright file="ModuleConfiguration.cs" company="Andras Csanyi">
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
    public class ModuleConfiguration : IEntityTypeConfiguration<Module>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.ToTable("module");

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Description).HasColumnName("description");
            builder.Property(p => p.IsActive).HasColumnName("is_active");
            builder.Property(p => p.ModuleRoute).HasColumnName("module_route");

            builder.HasMany(p => p.Menus)
               .WithOne(q => q.Module)
               .HasForeignKey(w => w.ModuleId);
        }
    }
}