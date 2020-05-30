using IHasId = MasterData.DomainModel.Interfaces.IHasId;
using IHasName = MasterData.DomainModel.Interfaces.IHasName;

namespace DigitalLibrary.MasterData.DomainModel
{
    public class SourceFormat : IHasId, IHasName
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public int IsActive { get; set; }

        public DimensionStructure RootDimensionStructure { get; set; }

        public long? RootDimensionStructureId { get; set; }
    }
}