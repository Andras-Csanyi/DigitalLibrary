using System.Collections.Generic;

namespace DigitalLibrary.MasterData.DomainModel.DomainModel
{
    public class Dimension
    {
        public long Id { get; set; }

        public int IsActive { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<DimensionStructure> DimensionStructure { get; set; }

        public ICollection<DimensionDimensionValue> DimensionDimensionValues { get; set; }
    }
}