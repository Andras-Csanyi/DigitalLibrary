using System.Collections.Generic;

namespace DigitalLibrary.MasterData.DomainModel.DomainModel
{
    public class DimensionStructure
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public int IsActive { get; set; }

        public long? ParentDimensionStructureId { get; set; }

        public DimensionStructure ParentDimensionStructure { get; set; }

        public ICollection<DimensionStructure> ChildDimensionStructures { get; set; }

        public long? DimensionId { get; set; }

        public Dimension Dimension { get; set; }

        public int SortOrder { get; set; }
    }
}