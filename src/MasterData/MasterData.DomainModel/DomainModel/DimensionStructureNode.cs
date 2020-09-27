namespace DigitalLibrary.MasterData.DomainModel
{
    using DigitalLibrary.MasterData.DomainModel.Interfaces;

    public class DimensionStructureNode : IHaveId
    {
        public long Id { get; set; }

        public long DimensionStructureId { get; set; }

        public DimensionStructure DimensionStructure { get; set; }

        public long ChildDimensionStructureId { get; set; }

        public DimensionStructure ChildDimensionStructure { get; set; }

        public long ParentDimensionStructureId { get; set; }

        public DimensionStructure ParentDimensionStructure { get; set; }
    }
}