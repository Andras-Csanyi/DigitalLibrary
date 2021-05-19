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
        public async Task<DimensionStructureNode> GetDimensionStructureNodeById(
            long id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                Check.AreNotEqual(id, 0);

                using (MasterDataContext ctx = new(_dbContextOptions))
                {
                    return await ctx.DimensionStructureNodes
                       .FirstOrDefaultAsync(
                            k => k.Id == id,
                            cancellationToken)
                       .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                             $"{nameof(GetDimensionStructureNodeById)} operation failed. " +
                             $"For further information see inner exception.";
                throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
            }
        }
    }
}
