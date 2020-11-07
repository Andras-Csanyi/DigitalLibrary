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
        /// <inheritdoc />
        public async Task<DimensionStructureNode> GetNodeAsync(
            long sourceFormatId,
            long dimensionStructureId,
            CancellationToken cancellationToken = default)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    Check.AreNotEqual(sourceFormatId, 0);
                    Check.AreNotEqual(dimensionStructureId, 0);

                    DimensionStructureNode node = await ctx.DimensionStructureNodes
                       .AsNoTracking()
                       .Where(w => w.SourceFormatId == sourceFormatId)
                       .FirstOrDefaultAsync(
                            ww => ww.DimensionStructureId == dimensionStructureId,
                            cancellationToken)
                       .ConfigureAwait(false);

                    return node;
                }
                catch (Exception e)
                {
                    string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                                 $"{nameof(GetNodeAsync)} operation failed. " +
                                 $"For further info see inner exception.";
                    throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
                }
            }
        }
    }
}