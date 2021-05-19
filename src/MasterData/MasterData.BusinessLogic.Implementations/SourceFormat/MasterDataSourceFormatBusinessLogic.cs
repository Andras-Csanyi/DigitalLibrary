namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc/>
    public partial class MasterDataSourceFormatBusinessLogic : IMasterDataSourceFormatBusinessLogic
    {
        private readonly DbContextOptions<MasterDataContext> _dbContextOptions;

        private readonly IMasterDataValidators _masterDataValidators;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MasterDataSourceFormatBusinessLogic"/> class.
        /// </summary>
        /// <param name="dbContextOptions">
        ///     Instance of <see cref="DbContextOptions<MasterDataContext> "/>.
        /// </param>
        /// <param name="masterDataValidators">
        ///     Instance of <see cref="IMasterDataValidators"/>.
        /// </param>
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