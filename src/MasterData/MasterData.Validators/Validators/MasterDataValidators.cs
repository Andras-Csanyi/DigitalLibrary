namespace DigitalLibrary.IaC.MasterData.Validators.Validators
{
    public class MasterDataValidators : IMasterDataValidators
    {
        public MasterDataValidators(
            MasterDataDimensionValidator dimensionValidator,
            MasterDataDimensionValueValidator dimensionValueValidator,
            DimensionStructureValidator dimensionStructureValidator)
        {
            if (dimensionValidator == null
                || dimensionValueValidator == null
                || dimensionStructureValidator == null)
            {
                throw new MasterDataValidatorFacadeArgumentNullException();
            }

            DimensionValidator = dimensionValidator;
            DimensionValueValidator = dimensionValueValidator;
            DimensionStructureValidator = dimensionStructureValidator;
        }

        public MasterDataDimensionValidator DimensionValidator { get; }

        public MasterDataDimensionValueValidator DimensionValueValidator { get; }

        public DimensionStructureValidator DimensionStructureValidator { get; }
    }
}