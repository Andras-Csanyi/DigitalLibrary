namespace DigitalLibrary.IaC.MasterData.DomainModel.DomainModel
{
    using System.Collections.Generic;

    public class Dimension
    {
        public long Id { get; set; }

        public int IsActive { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<DimensionDimensionValue> DimensionDimensionValues { get; set; }
    }
}