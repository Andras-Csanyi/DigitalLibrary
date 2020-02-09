namespace DigitalLibrary.MasterData.Validators
{
    public interface IMasterDataValidators
    {
        public DimensionValidator DimensionValidator { get; }

        public MasterDataDimensionValueValidator DimensionValueValidator { get; }

        public SourceFormatValidator SourceFormatValidator { get; }

        public DimensionStructureValidator DimensionStructureValidator { get; }

        public DimensionStructureDimensionStructureValidator DimensionStructureDimensionStructureValidator { get; }
    }
}