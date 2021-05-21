namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionValue
{
    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataDimensionValueBusinessLogic : IMasterDataDimensionValueBusinessLogic
    {
        private readonly DbContextOptions<MasterDataContext> _dbContextOptions;

        private readonly IMasterDataValidators _masterDataValidators;

        public MasterDataDimensionValueBusinessLogic(
            DbContextOptions<MasterDataContext> dbContextOptions,
            IMasterDataValidators masterDataValidators)
        {
            Check.IsNotNull(dbContextOptions);
            Check.IsNotNull(masterDataValidators);

            _dbContextOptions = dbContextOptions;
            _masterDataValidators = masterDataValidators;
        }
    }
}
