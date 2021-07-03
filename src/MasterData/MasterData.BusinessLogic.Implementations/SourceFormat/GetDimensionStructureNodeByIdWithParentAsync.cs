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
        public async Task<DimensionStructureNode> GetDimensionStructureNodeByIdWithParentAsync(
            long nodeId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                Check.AreNotEqual(nodeId, 0);

                using (MasterDataContext ctx = new (_dbContextOptions))
                {
                    return await ctx.DimensionStructureNodes
                       .Include(i => i.ParentNode)
                       .FirstOrDefaultAsync(
                            k => k.Id == nodeId,
                            cancellationToken)
                       .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                             $"{nameof(GetDimensionStructureNodeByIdWithParentAsync)} operation has failed. " +
                             $"For further information, see inner exception.";
                throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg);
            }
        }
    }
}
