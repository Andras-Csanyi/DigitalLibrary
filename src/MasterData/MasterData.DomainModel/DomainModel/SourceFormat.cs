namespace DigitalLibrary.MasterData.DomainModel
{
    using System;

    using Interfaces;

    public class SourceFormat : IHaveId, IHaveName, IHaveGuidId
    {
        public string Desc { get; set; }

        public int IsActive { get; set; }

        public DimensionStructure RootDimensionStructure { get; set; }

        public long? RootDimensionStructureId { get; set; }

        public SourceFormat()
        {
            Guid = Guid.NewGuid();
        }

        public Guid Guid { get; set; }

        public long Id { get; set; }

        public string Name { get; set; }
    }
}