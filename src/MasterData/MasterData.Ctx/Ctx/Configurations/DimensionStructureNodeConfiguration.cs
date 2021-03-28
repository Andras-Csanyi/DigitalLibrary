namespace DigitalLibrary.MasterData.Ctx.Configurations
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <inheritdoc />
    public class DimensionStructureNodeConfiguration
        : IEntityTypeConfiguration<DimensionStructureNode>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<DimensionStructureNode> builder)
        {
            Check.IsNotNull(builder);

            builder.ToTable("dimensionstructure_nodes");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id");

            builder.Property(p => p.ChildNodeId).HasColumnName("parent_id");

            builder.Property(p => p.DimensionStructureId).HasColumnName("dimensionstructure_id");

            builder.Property(p => p.SourceFormatId).HasColumnName("sourceformat_id");

            builder.Property(p => p.IsActive).HasColumnName("is_active");
            builder.Property(p => p.IsActive).HasDefaultValue(1);

            builder.HasMany(m => m.ChildNodes)
               .WithOne(o => o.ChildNode)
               .HasForeignKey(k => k.ChildNodeId)
               .IsRequired(false);

            builder.HasOne(o => o.SourceFormat)
               .WithMany(m => m.DimensionStructureNodes)
               .HasForeignKey(k => k.SourceFormatId)
               .IsRequired(false);

            builder.HasOne(o => o.DimensionStructure)
               .WithMany(m => m.DimensionStructureNodes)
               .HasForeignKey(k => k.DimensionStructureId);
        }
    }
}