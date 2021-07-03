namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<int> GetAmountOfDimensionStructureNodeOfSourceFormatAsync(
            SourceFormat sf,
            CancellationToken cancellationToken = default)
        {
            try
            {
                Check.IsNotNull(sf);

                return await GetAmountOfDimensionStructureNodeOfSourceFormatAsync(sf.Id, cancellationToken)
                   .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                             $"{nameof(GetAmountOfDimensionStructureNodeOfSourceFormatAsync)} operation failed. " +
                             "For further information see inner exception.";
                throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
            }
        }

        /// <inheritdoc/>
        public async Task<int> GetAmountOfDimensionStructureNodeOfSourceFormatAsync(
            long id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                Check.AreNotEqual(id, 0);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    return await ctx.DimensionStructureNodes.CountAsync(
                            p => p.SourceFormatId == id,
                            cancellationToken)
                       .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                             $"{nameof(GetAmountOfDimensionStructureNodeOfSourceFormatAsync)} operation failed. " +
                             "For further information see inner exception.";
                throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
            }
        }
    }
}
