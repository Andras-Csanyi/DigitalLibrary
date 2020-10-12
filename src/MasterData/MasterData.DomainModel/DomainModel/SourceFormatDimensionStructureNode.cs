namespace DigitalLibrary.MasterData.DomainModel
{
    using DigitalLibrary.MasterData.DomainModel.Interfaces;

    public class SourceFormatDimensionStructureNode : IHaveId
    {
        public DimensionStructureNode DimensionStructureNode { get; set; }

        public long DimensionStructureNodeId { get; set; }

        public SourceFormat SourceFormat { get; set; }

        public long SourceFormatId { get; set; }

        public long Id { get; set; }
    }
}