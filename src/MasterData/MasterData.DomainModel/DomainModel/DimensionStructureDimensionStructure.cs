namespace DigitalLibrary.MasterData.DomainModel
{
    public class DimensionStructureDimensionStructure
    {
        public long Id { get; set; }

        public long ParentDimensionStructureId { get; set; }

        public DimensionStructure ParentDimensionStructure { get; set; }

        public long ChildDimensionStructureId { get; set; }

        public DimensionStructure ChildDimensionStructure { get; set; }
    }
}