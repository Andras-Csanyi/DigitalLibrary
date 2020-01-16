using System.Collections.Generic;

namespace DigitalLibrary.MasterData.DomainModel.DomainModel
{
    public class DimensionValue
    {
        public long Id { get; set; }

        public string Value { get; set; }

        public ICollection<DimensionDimensionValue> DimensionDimensionValues { get; set; }
    }
}