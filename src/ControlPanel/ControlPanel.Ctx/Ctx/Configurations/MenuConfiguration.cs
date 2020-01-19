namespace DigitalLibrary.ControlPanel.Ctx.Ctx.Configurations
{
    using DomainModel.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
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