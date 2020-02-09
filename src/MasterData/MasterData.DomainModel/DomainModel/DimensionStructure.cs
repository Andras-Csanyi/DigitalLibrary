namespace DigitalLibrary.MasterData.DomainModel
{
    using System.Collections.Generic;

    public class DimensionStructure
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public int IsActive { get; set; }

        public ICollection<SourceFormat> SourceFormats { get; set; }

        public IEnumerable<DimensionStructureDimensionStructure> DimensionStructureDimensionStructures { get; set; }

        public long? DimensionId { get; set; }

        public Dimension Dimension { get; set; }

        public int SortOrder { get; set; }

        /// <summary>
        /// WARNING!!! It is used only when SourceFormat is built.
        /// </summary>
        public IEnumerable<DimensionStructure> ChildDimensionStructures { get; set; }
    }
}