namespace DigitalLibrary.MasterData.DomainModel
{
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.DomainModel.Interfaces;

    public class DimensionStructureNode : IHaveId
    {
        public long Id { get; set; }

        public DimensionStructure DimensionStructure { get; set; }

        public long? DimensionStructureId { get; set; }

        public ICollection<DimensionStructureNode> ChildNodes { get; set; } = new List<DimensionStructureNode>();

        public DimensionStructureNode ChildNode { get; set; }

        public long? ChildNodeId { get; set; }

        /// <summary>
        /// Gets or sets <see cref="SourceFormat"/>.
        /// This property marks to which <see cref="SourceFormat"/> the node belongs to.
        /// </summary>
        public SourceFormat SourceFormat { get; set; }

        /// <summary>
        /// Gets or sets SourceFormatId. It is a reference to <see cref="SourceFormat"/>.
        /// </summary>
        public long? SourceFormatId { get; set; }

        /// <summary>
        /// Gets or sets <see cref="SourceFormatDimensionStructureNode"/>.
        /// Via this navigation property the fact is setup the node is root dimension structure of a
        /// <see cref="SourceFormat"/>.
        /// </summary>
        public SourceFormatDimensionStructureNode SourceFormatDimensionStructureNode { get; set; }
    }
}