namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
{
    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataDimensionStructureBusinessLogic : IMasterDataDimensionStructureBusinessLogic
    {
        private readonly DbContextOptions<MasterDataContext> _dbContextOptions;

        private readonly IMasterDataValidators _masterDataValidators;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MasterDataDimensionStructureBusinessLogic"/> class.
        /// </summary>
        /// <param name="dbContextOptions"> <see cref="DbContextOptions"/> for MasterDataContext. </param>
        /// <param name="masterDataValidators"> Validators of MasterDataContext. </param>
        public MasterDataDimensionStructureBusinessLogic(
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
