namespace DigitalLibrary.IaC.MasterData.Validators.Validators
{
    public interface IMasterDataValidators
    {
        public MasterDataDimensionValidator DimensionValidator { get; }

        public MasterDataDimensionValueValidator DimensionValueValidator { get; }

        public DimensionStructureValidator DimensionStructureValidator { get; }
    }
}