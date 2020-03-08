namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Interfaces;

    using Microsoft.EntityFrameworkCore;

    using Utils.Guards;

    using Validators;

    public partial class MasterDataBusinessLogic : IMasterDataBusinessLogic
    {
        private readonly DbContextOptions<MasterDataContext> _dbContextOptions;

        private readonly IMasterDataValidators _masterDataValidators;

        public MasterDataBusinessLogic(
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