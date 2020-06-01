using IHasId = DigitalLibrary.MasterData.DomainModel.Interfaces.IHasId;
using IHasName = DigitalLibrary.MasterData.DomainModel.Interfaces.IHasName;

namespace DigitalLibrary.MasterData.DomainModel
{
    using System.Collections.Generic;

    using Interfaces;

    public class Dimension : IHasId, IHasName
    {
        public long Id { get; set; }

        public int IsActive { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<DimensionStructure> DimensionStructure { get; set; }

        public ICollection<DimensionDimensionValue> DimensionDimensionValues { get; set; }
    }
}