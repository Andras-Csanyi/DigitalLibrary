namespace DigitalLibrary.MasterData.DomainModel
{
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.DomainModel.Interfaces;

    public class DimensionStructureNode : IHaveId
    {
        public long Id { get; set; }

        public DimensionStructure DimensionStructure { get; set; }

        public long DimensionStructureId { get; set; }

        public ICollection<DimensionStructureNode> ChildNodes { get; set; }

        public DimensionStructureNode ChildNode { get; set; }

        public long ChildNodeId { get; set; }
    }
}