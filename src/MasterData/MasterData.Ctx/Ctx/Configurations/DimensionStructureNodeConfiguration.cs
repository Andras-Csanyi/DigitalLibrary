namespace DigitalLibrary.MasterData.Ctx.Configurations
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DimensionStructureNodeConfiguration
        : IEntityTypeConfiguration<DimensionStructureNode>
    {
        public void Configure(EntityTypeBuilder<DimensionStructureNode> builder)
        {
            Check.IsNotNull(builder);

            builder.ToTable("dimensionstructurenodes");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id");

            builder.Property(p => p.ChildNodeId).HasColumnName("child_id");

            builder.Property(p => p.DimensionStructureId).HasColumnName("dimensionstructure_id");

            builder.HasMany(m => m.ChildNodes)
               .WithOne(o => o.ChildNode)
               .HasForeignKey(k => k.ChildNodeId)
               .IsRequired(false);
        }
    }
}