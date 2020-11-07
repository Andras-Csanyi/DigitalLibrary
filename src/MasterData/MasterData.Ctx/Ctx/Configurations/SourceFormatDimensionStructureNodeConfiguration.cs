namespace DigitalLibrary.MasterData.Ctx.Configurations
{
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <inheritdoc />
    public class SourceFormatDimensionStructureNodeConfiguration
        : IEntityTypeConfiguration<SourceFormatDimensionStructureNode>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<SourceFormatDimensionStructureNode> builder)
        {
            Check.IsNotNull(builder);

            builder.ToTable("sourceformat_dimensionstructurenode");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");

            builder.Property(p => p.SourceFormatId).HasColumnName("sourceformat_id");

            builder.Property(p => p.DimensionStructureNodeId).HasColumnName("dimensionstructurenode_id");

            builder.HasOne(p => p.SourceFormat)
               .WithOne(p => p.SourceFormatDimensionStructureNode)
               .HasForeignKey<SourceFormatDimensionStructureNode>(k => k.SourceFormatId)
               .IsRequired(false);

            builder.HasOne(p => p.DimensionStructureNode)
               .WithOne(p => p.SourceFormatDimensionStructureNode)
               .HasForeignKey<SourceFormatDimensionStructureNode>(k => k.DimensionStructureNodeId);
        }
    }
}