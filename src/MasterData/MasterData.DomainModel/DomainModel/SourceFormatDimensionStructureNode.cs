namespace DigitalLibrary.MasterData.DomainModel
{
    using DigitalLibrary.MasterData.DomainModel.Interfaces;

    public class SourceFormatDimensionStructureNode : IHaveId
    {
        public long Id { get; set; }

        public SourceFormat SourceFormat { get; set; }

        public long SourceFormatId { get; set; }

        public DimensionStructureNode DimensionStructureNode { get; set; }

        public long DimensionStructureNodeId { get; set; }
    }
}