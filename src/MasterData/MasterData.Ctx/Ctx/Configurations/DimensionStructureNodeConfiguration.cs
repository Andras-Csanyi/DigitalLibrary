namespace DigitalLibrary.MasterData.Ctx.Configurations
{
    using System;

    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DimensionStructureNodeConfiguration : IEntityTypeConfiguration<DimensionStructureNode>
    {
        public void Configure(EntityTypeBuilder<DimensionStructureNode> builder)
        {
            Check.IsNotNull(builder);

            builder.ToTable("dimensionstructure_node");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Id).HasColumnName("node_id");

            builder.Property(p => p.DimensionStructureId).HasColumnName("dimensionstructure_id");
            builder.Property(p => p.DimensionStructureId).IsRequired(false);

            builder.Property(p => p.ParentDimensionStructureId).HasColumnName("parent_dimensionstructure_id");
            builder.Property(p => p.ParentDimensionStructureId).IsRequired(false);

            builder.Property(p => p.ChildDimensionStructureId).HasColumnName("child_dimensionstructure_id");
            builder.Property(p => p.ChildDimensionStructureId).IsRequired(false);
        }
    }
}