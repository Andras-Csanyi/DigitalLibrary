using IHasId = MasterData.DomainModel.Interfaces.IHasId;

namespace DigitalLibrary.MasterData.DomainModel
{
    public class DimensionStructureDimensionStructure : IHasId
    {
        public long Id { get; set; }

        public long DimensionStructureId { get; set; }

        public DimensionStructure DimensionStructure { get; set; }

        public long ParentDimensionStructureId { get; set; }

        public long ChildDimensionStructureId { get; set; }
    }
}