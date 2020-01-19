namespace DigitalLibrary.MasterData.DomainModel
{
    public class DimensionDimensionValue
    {
        public long Id { get; set; }

        public long DimensionValueId { get; set; }

        public DimensionValue DimensionValue { get; set; }

        public Dimension Dimension { get; set; }

        public long DimensionId { get; set; }
    }
}