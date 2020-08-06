namespace DigitalLibrary.MasterData.DomainModel
{
    using Interfaces;

    public class DimensionDimensionValue : IHaveId
    {
        public long Id { get; set; }

        public long DimensionValueId { get; set; }

        public DimensionValue DimensionValue { get; set; }

        public Dimension Dimension { get; set; }

        public long DimensionId { get; set; }
    }
}