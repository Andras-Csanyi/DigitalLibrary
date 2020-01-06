namespace DigitalLibrary.IaC.ControlPanel.Ctx.Context.Configurations
{
    using DomainModel.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ModuleConfiguration : IEntityTypeConfiguration<Module>
    {
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