namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatBusinessLogic : IMasterDataSourceFormatBusinessLogic
    {
        private readonly DbContextOptions<MasterDataContext> _dbContextOptions;

        private readonly IMasterDataValidators _masterDataValidators;

        public MasterDataSourceFormatBusinessLogic(
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