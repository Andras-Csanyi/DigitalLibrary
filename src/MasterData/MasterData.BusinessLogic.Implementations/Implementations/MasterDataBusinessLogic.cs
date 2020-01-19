namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using Ctx.Ctx;

    using Exceptions;

    using Interfaces.Interfaces;

    using Microsoft.EntityFrameworkCore;

    using Validators.Validators;

    public partial class MasterDataBusinessLogic : IMasterDataBusinessLogic
    {
        private readonly DbContextOptions<MasterDataContext> _dbContextOptions;

        private readonly IMasterDataValidators _masterDataValidators;

        public MasterDataBusinessLogic(
            DbContextOptions<MasterDataContext> dbContextOptions,
            IMasterDataValidators masterDataValidators)
        {
            if (dbContextOptions == null
             || masterDataValidators == null)
            {
                throw new MasterDataBusinessLogicArgumentNullException(nameof(dbContextOptions));
            }

            _dbContextOptions = dbContextOptions;
            _masterDataValidators = masterDataValidators;
        }
    }
}