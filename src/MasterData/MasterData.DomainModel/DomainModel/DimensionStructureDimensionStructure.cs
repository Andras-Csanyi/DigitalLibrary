namespace DigitalLibrary.MasterData.DomainModel
{
    using Interfaces;

    public class DimensionStructureDimensionStructure : IHaveId
    {
        public long Id { get; set; }

        public long DimensionStructureId { get; set; }

        public DimensionStructure DimensionStructure { get; set; }

        public long ParentDimensionStructureId { get; set; }

        public long ChildDimensionStructureId { get; set; }
    }
}