// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.DomainModel
{
    using Interfaces;

    public class DimensionStructureDimensionStructure : IHaveId
    {
        public long ChildDimensionStructureId { get; set; }

        public DimensionStructure DimensionStructure { get; set; }

        public long DimensionStructureId { get; set; }

        public long ParentDimensionStructureId { get; set; }

        public long Id { get; set; }
    }
}