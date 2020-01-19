namespace DigitalLibrary.MasterData.Validators
{
    public interface IMasterDataValidators
    {
        public MasterDataDimensionValidator DimensionValidator { get; }

        public MasterDataDimensionValueValidator DimensionValueValidator { get; }

        public TopDimensionStructureValidator TopDimensionStructureValidator { get; }

        public DimensionStructureValidator DimensionStructureValidator { get; }
    }
}