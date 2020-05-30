using IHasId = MasterData.DomainModel.Interfaces.IHasId;

namespace DigitalLibrary.MasterData.DomainModel
{
    using System.Collections.Generic;

    public class DimensionValue : IHasId
    {
        public long Id { get; set; }

        public string Value { get; set; }

        public ICollection<DimensionDimensionValue> DimensionDimensionValues { get; set; }
    }
}