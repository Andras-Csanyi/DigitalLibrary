using DigitalLibrary.MasterData.BusinessLogic.Exceptions.Exceptions;
using DigitalLibrary.MasterData.BusinessLogic.Interfaces.Interfaces;
using DigitalLibrary.MasterData.Ctx.Ctx;
using DigitalLibrary.MasterData.Validators.Validators;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Implementations
{
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