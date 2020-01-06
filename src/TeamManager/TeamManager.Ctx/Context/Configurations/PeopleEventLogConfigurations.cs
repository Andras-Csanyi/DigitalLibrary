namespace DigitalLibrary.IaC.TeamManager.Ctx.Context.Configurations
{
    using DomainModel.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PeopleEventLogConfigurations : IEntityTypeConfiguration<PeopleEventLog>
    {
        public void Configure(EntityTypeBuilder<PeopleEventLog> builder)
        {
            builder.ToTable("people_event_log");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Details).HasColumnName("details");
            builder.Property(p => p.IsActive).HasColumnName("is_active");
            builder.Property(p => p.PeopleId).HasColumnName("people_id");
            builder.Property(p => p.EventId).HasColumnName("event_id");

            builder.HasOne(p => p.People)
                .WithMany(p => p.PeopleEventLogs)
                .HasForeignKey(p => p.PeopleId);

            builder.HasOne(p => p.Event)
                .WithMany(p => p.PeopleEventLogs)
                .HasForeignKey(p => p.EventId);
        }
    }
}