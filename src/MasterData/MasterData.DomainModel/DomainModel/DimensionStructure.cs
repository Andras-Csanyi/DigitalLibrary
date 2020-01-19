namespace DigitalLibrary.MasterData.DomainModel
{
    using System.Collections.Generic;

    public class DimensionStructure
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public int IsActive { get; set; }

        public IEnumerable<SourceFormatDimensionStructure> ParentSourceFormatDimensionStructures { get; set; }

        public ICollection<DimensionStructure> ChildDimensionStructures { get; set; }

        public long? DimensionId { get; set; }

        public Dimension Dimension { get; set; }

        public int SortOrder { get; set; }
    }
}