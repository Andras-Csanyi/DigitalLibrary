namespace DigitalLibrary.MasterData.DomainModel
{
    using System.Collections;
    using System.Collections.Generic;

    public class SourceFormatDimensionStructure
    {
        public long Id { get; set; }

        public long SourceFormatId { get; set; }

        public SourceFormat SourceFormat { get; set; }

        public long DimensionStructureId { get; set; }

        public DimensionStructure DimensionStructure { get; set; }
    }
}