namespace DigitalLibrary.MasterData.DomainModel
{
    using DigitalLibrary.MasterData.DomainModel.Interfaces;

    public class DimensionStructureDimensionStructure : IHaveId
    {
        public long Id { get; set; }

        public DimensionStructure DimensionStructure { get; set; }

        public long DimensionStructureId { get; set; }

        public DimensionStructure ChildDimensionStructure { get; set; }

        public long ChildDimensionStructureId { get; set; }
    }
}