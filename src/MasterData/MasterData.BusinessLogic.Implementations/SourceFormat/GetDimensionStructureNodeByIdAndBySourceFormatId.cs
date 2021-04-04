namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<DimensionStructureNode> GetDimensionStructureNodeByIdAndBySourceFormatId(
            long dimensionStructureNodeId,
            long sourceFormatId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                Check.AreNotEqual(dimensionStructureNodeId, 0);
                Check.AreNotEqual(sourceFormatId, 0);

                using (MasterDataContext ctx = new(_dbContextOptions))
                {
                    return await ctx.DimensionStructureNodes
                       .Where(w => w.SourceFormatId == sourceFormatId)
                       .FirstOrDefaultAsync(
                            ww => ww.Id == dimensionStructureNodeId,
                            cancellationToken)
                       .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                             $"{nameof(GetDimensionStructureNodeByIdAndBySourceFormatId)} operation failed. " +
                             $"For further details see inner exception.";
                throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
            }
        }
    }
}