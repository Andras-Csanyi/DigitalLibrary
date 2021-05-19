namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructureNode
{
    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataDimensionStructureNodeBusinessLogic : IMasterDataDimensionStructureNodeBusinessLogic
    {
        private readonly DbContextOptions<MasterDataContext> _dbContextOptions;

        private readonly IMasterDataValidators _masterDataValidators;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MasterDataDimensionStructureNodeBusinessLogic"/> class.
        /// </summary>
        /// <param name="dbContextOptions">
        ///     DbContext options for Master Data context.
        /// </param>
        /// <param name="masterDataValidators">
        ///     Validators used in Master Data context.
        /// </param>
        public MasterDataDimensionStructureNodeBusinessLogic(
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