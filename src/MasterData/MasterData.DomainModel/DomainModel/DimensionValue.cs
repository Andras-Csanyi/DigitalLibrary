// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.DomainModel
{
    using System.Collections.Generic;

    using Interfaces;

    public class DimensionValue : IHaveId
    {
        public ICollection<DimensionDimensionValue> DimensionDimensionValues { get; set; }

        public string Value { get; set; }

        public long Id { get; set; }
    }
}