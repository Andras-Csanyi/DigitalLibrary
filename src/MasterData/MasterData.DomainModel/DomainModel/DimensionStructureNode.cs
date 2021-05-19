namespace DigitalLibrary.MasterData.DomainModel
{
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.DomainModel.Interfaces;

    /// <summary>
    ///     DimensionStructureNode object which describes the structural part of a node
    ///     in the DimensionStructure tree. It provides a hook where the not structural
    ///     property representatives, such as <see cref="DimensionStructure"/> can be attached.
    /// </summary>
    public class DimensionStructureNode : IHaveId, IHaveIsActive
    {
        /// <summary>
        ///     Gets or sets ParentNode value.
        ///     Parent <see cref="DimensionStructureNode"/> of this instance.
        /// </summary>
        public DimensionStructureNode ParentNode { get; set; }

        /// <summary>
        ///     Gets or sets ParentNodeId value.
        /// </summary>
        public long? ParentNodeId { get; set; }

        /// <summary>
        ///     Gets or sets ChildNodes value.
        ///     The list represents those <see cref="DimensionStructureNode"/>nodes which children of the given instance.
        ///     The children items has this specific instance set up as their Parent node.
        /// </summary>
        public ICollection<DimensionStructureNode> ChildNodes { get; } = new List<DimensionStructureNode>();

        public DimensionStructure DimensionStructure { get; set; }

        public long? DimensionStructureId { get; set; }

        /// <summary>
        ///     Gets or sets <see cref="SourceFormat"/>.
        ///     This property marks to which <see cref="SourceFormat"/> the node belongs to.
        /// </summary>
        public SourceFormat SourceFormat { get; set; }

        /// <summary>
        ///     Gets or sets SourceFormatId. It is a reference to <see cref="SourceFormat"/>.
        /// </summary>
        public long? SourceFormatId { get; set; }

        /// <summary>
        ///     Gets or sets <see cref="SourceFormatDimensionStructureNode"/>.
        ///     Via this navigation property the fact is setup the node is root dimension structure of a
        ///     <see cref="SourceFormat"/>.
        /// </summary>
        public SourceFormatDimensionStructureNode SourceFormatDimensionStructureNode { get; set; }

        /// <inheritdoc/>
        public long Id { get; set; }

        /// <inheritdoc/>
        public int IsActive { get; set; }
    }
}