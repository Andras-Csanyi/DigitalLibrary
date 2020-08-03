namespace DigitalLibrary.MasterData.Validators
{
    using Utils.Guards;

    public class MasterDataValidators : IMasterDataValidators
    {
        public MasterDataValidators(
            DimensionValidator dimensionValidator,
            MasterDataDimensionValueValidator dimensionValueValidator,
            SourceFormatValidator sourceFormatValidator,
            DimensionStructureValidator dimensionStructureValidator,
            DimensionStructureDimensionStructureValidator dimensionStructureDimensionStructureValidator,
            DimensionStructureQueryObjectValidator dimensionStructureQueryObjectValidator)
        {
            Check.IsNotNull(dimensionValidator);
            Check.IsNotNull(dimensionValueValidator);
            Check.IsNotNull(sourceFormatValidator);
            Check.IsNotNull(dimensionStructureValidator);
            Check.IsNotNull(dimensionStructureDimensionStructureValidator);
            Check.IsNotNull(dimensionStructureQueryObjectValidator);

            DimensionValidator = dimensionValidator;
            DimensionValueValidator = dimensionValueValidator;
            SourceFormatValidator = sourceFormatValidator;
            DimensionStructureValidator = dimensionStructureValidator;
            DimensionStructureDimensionStructureValidator = dimensionStructureDimensionStructureValidator;
            DimensionStructureQueryObjectValidator = dimensionStructureQueryObjectValidator;
        }

        public DimensionValidator DimensionValidator { get; }

        public MasterDataDimensionValueValidator DimensionValueValidator { get; }

        public SourceFormatValidator SourceFormatValidator { get; }

        public DimensionStructureValidator DimensionStructureValidator { get; }

        public DimensionStructureDimensionStructureValidator DimensionStructureDimensionStructureValidator { get; }

        public DimensionStructureQueryObjectValidator DimensionStructureQueryObjectValidator { get; }
    }
}