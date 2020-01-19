namespace DigitalLibrary.MasterData.Validators
{
    public class MasterDataValidators : IMasterDataValidators
    {
        public MasterDataValidators(
            MasterDataDimensionValidator dimensionValidator,
            MasterDataDimensionValueValidator dimensionValueValidator,
            TopDimensionStructureValidator topDimensionStructureValidator,
            DimensionStructureValidator dimensionStructureValidator)
        {
            if (dimensionValidator == null
             || dimensionValueValidator == null
             || topDimensionStructureValidator == null
             || dimensionStructureValidator == null)
            {
                throw new MasterDataValidatorFacadeArgumentNullException();
            }

            DimensionValidator = dimensionValidator;
            DimensionValueValidator = dimensionValueValidator;
            TopDimensionStructureValidator = topDimensionStructureValidator;
            DimensionStructureValidator = dimensionStructureValidator;
        }

        public MasterDataDimensionValidator DimensionValidator { get; }

        public MasterDataDimensionValueValidator DimensionValueValidator { get; }

        public TopDimensionStructureValidator TopDimensionStructureValidator { get; }

        public DimensionStructureValidator DimensionStructureValidator { get; }
    }
}