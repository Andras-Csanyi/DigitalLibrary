namespace DigitalLibrary.MasterData.DomainModel
{
    using System.Collections.Generic;

    public class SourceFormat
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public int IsActive { get; set; }

        public IEnumerable<SourceFormatDimensionStructure> ChildDimensionStructures { get; set; }
    }
}