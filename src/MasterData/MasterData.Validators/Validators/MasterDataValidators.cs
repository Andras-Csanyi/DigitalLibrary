namespace DigitalLibrary.MasterData.Validators
{
    public class MasterDataValidators : IMasterDataValidators
    {
        public MasterDataValidators(
            DimensionValidator dimensionValidator,
            MasterDataDimensionValueValidator dimensionValueValidator,
            SourceFormatValidator sourceFormatValidator,
            DimensionStructureValidator dimensionStructureValidator)
        {
            if (dimensionValidator == null
             || dimensionValueValidator == null
             || sourceFormatValidator == null
             || dimensionStructureValidator == null)
            {
                throw new MasterDataValidatorFacadeArgumentNullException();
            }

            DimensionValidator = dimensionValidator;
            DimensionValueValidator = dimensionValueValidator;
            SourceFormatValidator = sourceFormatValidator;
            DimensionStructureValidator = dimensionStructureValidator;
        }

        public DimensionValidator DimensionValidator { get; }

        public MasterDataDimensionValueValidator DimensionValueValidator { get; }

        public SourceFormatValidator SourceFormatValidator { get; }

        public DimensionStructureValidator DimensionStructureValidator { get; }
    }
}