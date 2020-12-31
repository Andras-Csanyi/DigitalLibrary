namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormatDimensionStructureNode
{
    using System;

    using DigitalLibrary.MasterData.BusinessLogic.Interfaces;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    ///     Business logic for <see cref="SourceFormatDimensionStructureNode" /> in Master Data domain.
    /// </summary>
    public partial class MasterDataSourceFormatDimensionStructureNodeBusinessLogic
        : IMasterDataSourceFormatDimensionStructureNodeBusinessLogic
    {
        private readonly DbContextOptions<MasterDataContext> _dbContextOptions;

        private readonly IMasterDataValidators _masterDataValidators;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MasterDataSourceFormatDimensionStructureNodeBusinessLogic" /> class.
        /// </summary>
        /// <param name="dbContextOptions">
        ///     Database related options.
        ///     <see cref="DbContextOptions{T}" />.
        /// </param>
        /// <param name="masterDataValidators"><see cref="MasterDataValidators" />.</param>
        public MasterDataSourceFormatDimensionStructureNodeBusinessLogic(
            DbContextOptions<MasterDataContext> dbContextOptions,
            IMasterDataValidators masterDataValidators)
        {
            _dbContextOptions = dbContextOptions ?? throw new ArgumentNullException(nameof(_dbContextOptions));
            _masterDataValidators = masterDataValidators ??
                                    throw new ArgumentNullException(nameof(_masterDataValidators));
        }
    }
}