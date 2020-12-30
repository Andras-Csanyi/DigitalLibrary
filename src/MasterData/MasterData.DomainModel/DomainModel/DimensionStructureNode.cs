namespace DigitalLibrary.MasterData.DomainModel
{
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.DomainModel.Interfaces;

    /// <summary>
    /// DimensionStructureNode object which describes the structural part of a node
    /// in the DimensionStructure tree. It provides a hook where the not structural
    /// property representatives, such as <see cref="DimensionStructure"/> can be attached.
    /// </summary>
    public class DimensionStructureNode : IHaveId, IHaveIsActive
    {
        public DimensionStructureNode ChildNode { get; set; }

        public long? ChildNodeId { get; set; }

        public ICollection<DimensionStructureNode> ChildNodes { get; set; } = new List<DimensionStructureNode>();

        public DimensionStructure DimensionStructure { get; set; }

        public long? DimensionStructureId { get; set; }

        /// <summary>
        ///     Gets or sets <see cref="SourceFormat" />.
        ///     This property marks to which <see cref="SourceFormat" /> the node belongs to.
        /// </summary>
        public SourceFormat SourceFormat { get; set; }

        /// <summary>
        ///     Gets or sets <see cref="SourceFormatDimensionStructureNode" />.
        ///     Via this navigation property the fact is setup the node is root dimension structure of a
        ///     <see cref="SourceFormat" />.
        /// </summary>
        public SourceFormatDimensionStructureNode SourceFormatDimensionStructureNode { get; set; }

        /// <summary>
        ///     Gets or sets SourceFormatId. It is a reference to <see cref="SourceFormat" />.
        /// </summary>
        public long? SourceFormatId { get; set; }

        public long Id { get; set; }

        /// <inheritdoc />
        public int IsActive { get; set; }
    }
}