namespace DigitalLibrary.MasterData.DomainModel
{
    using System;

    using DigitalLibrary.MasterData.DomainModel.Interfaces;

    public class SourceFormat : IHaveId, IHaveName, IHaveGuidId
    {
        public SourceFormat()
        {
            Guid = Guid.NewGuid();
        }

        public long Id { get; set; }

        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public int IsActive { get; set; }

        public DimensionStructure RootDimensionStructure { get; set; }

        public long? RootDimensionStructureId { get; set; }
    }
}