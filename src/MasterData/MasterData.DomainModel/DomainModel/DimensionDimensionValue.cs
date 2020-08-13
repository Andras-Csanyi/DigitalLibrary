// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.DomainModel
{
    using Interfaces;

    public class DimensionDimensionValue : IHaveId
    {
        public Dimension Dimension { get; set; }

        public long DimensionId { get; set; }

        public DimensionValue DimensionValue { get; set; }

        public long DimensionValueId { get; set; }

        public long Id { get; set; }
    }
}