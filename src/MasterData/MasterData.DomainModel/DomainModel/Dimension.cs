namespace DigitalLibrary.MasterData.DomainModel
{
    using System.Collections.Generic;

    using Interfaces;

    public class Dimension : IHaveId, IHaveName
    {
        public string Description { get; set; }

        public ICollection<DimensionDimensionValue> DimensionDimensionValues { get; set; }

        public ICollection<DimensionStructure> DimensionStructure { get; set; }

        public int IsActive { get; set; }

        public Dimension()
        {
        }

        public long Id { get; set; }

        public string Name { get; set; }
    }
}