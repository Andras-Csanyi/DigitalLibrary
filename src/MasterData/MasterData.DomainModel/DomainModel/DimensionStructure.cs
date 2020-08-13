// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.DomainModel
{
    using System;
    using System.Collections.Generic;

    using Interfaces;

    public class DimensionStructure : IHaveId, IHaveGuidId
    {
        /// <summary>
        ///     WARNING!!! It is used only when SourceFormat is built.
        /// </summary>
        public ICollection<DimensionStructure> ChildDimensionStructures { get; set; }

        public string Desc { get; set; }

        public Dimension Dimension { get; set; }

        public long? DimensionId { get; set; }

        public ICollection<DimensionStructureDimensionStructure> DimensionStructureDimensionStructures { get; set; }

        public int IsActive { get; set; }

        public string Name { get; set; }

        public int SortOrder { get; set; }

        public ICollection<SourceFormat> SourceFormats { get; set; }

        public DimensionStructure()
        {
            ChildDimensionStructures = new List<DimensionStructure>();
            Guid = Guid.NewGuid();
        }

        public Guid Guid { get; set; }

        public long Id { get; set; }
    }
}