namespace DigitalLibrary.MasterData.Validators
{
    public interface IMasterDataValidators
    {
        public MasterDataDimensionValidator DimensionValidator { get; }

        public MasterDataDimensionValueValidator DimensionValueValidator { get; }

        public SourceFormatValidator SourceFormatValidator { get; }

        public DimensionStructureValidator DimensionStructureValidator { get; }
    }
}