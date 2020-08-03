using IHasId = DigitalLibrary.MasterData.DomainModel.Interfaces.IHasId;

namespace DigitalLibrary.MasterData.DomainModel
{
    using Interfaces;

    public class DimensionDimensionValue : IHasId
    {
        public long Id { get; set; }

        public long DimensionValueId { get; set; }

        public DimensionValue DimensionValue { get; set; }

        public Dimension Dimension { get; set; }

        public long DimensionId { get; set; }
    }
}