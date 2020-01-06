namespace DigitalLibrary.IaC.TeamManager.Ctx.Context.Configurations
{
    using DomainModel.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PeopleConfigurations : IEntityTypeConfiguration<People>
    {
        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.ToTable("people");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.FirstName).HasColumnName("first_name");
            builder.Property(p => p.MiddleName).HasColumnName("middle_name");
            builder.Property(p => p.LastName).HasColumnName("last_name");
            builder.Property(p => p.PositionId).HasColumnName("position_id");
            builder.Property(p => p.CompanyId).HasColumnName("company_id");
            builder.Property(p => p.TitleId).HasColumnName("title_id");
            builder.Property(p => p.IsActive).HasColumnName("is_active");

            builder.HasOne(p => p.Position)
                .WithMany(p => p.Peoples)
                .HasForeignKey(p => p.PositionId);

            builder.HasOne(p => p.Company)
                .WithMany(p => p.Peoples)
                .HasForeignKey(p => p.CompanyId);

            builder.HasOne(p => p.Title)
                .WithMany(p => p.Peoples)
                .HasForeignKey(p => p.TitleId);
        }
    }
}