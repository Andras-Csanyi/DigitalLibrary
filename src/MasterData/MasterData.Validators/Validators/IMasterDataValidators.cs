namespace DigitalLibrary.MasterData.Validators
{
    public interface IMasterDataValidators
    {
        public DimensionStructureDimensionStructureValidator DimensionStructureDimensionStructureValidator { get; }

        public DimensionStructureQueryObjectValidator DimensionStructureQueryObjectValidator { get; }

        public DimensionStructureValidator DimensionStructureValidator { get; }

        public DimensionValidator DimensionValidator { get; }

        public MasterDataDimensionValueValidator DimensionValueValidator { get; }

        public SourceFormatValidator SourceFormatValidator { get; }
    }
}