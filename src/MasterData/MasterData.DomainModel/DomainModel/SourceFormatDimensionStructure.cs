namespace DigitalLibrary.MasterData.DomainModel
{
    using DigitalLibrary.MasterData.DomainModel.Interfaces;

    public class SourceFormatDimensionStructure : IHaveId
    {
        public long Id { get; set; }

        public SourceFormat SourceFormat { get; set; }

        public long SourceFormatId { get; set; }

        public DimensionStructure DimensionStructure { get; set; }

        public long DimensionStructureId { get; set; }
    }
}