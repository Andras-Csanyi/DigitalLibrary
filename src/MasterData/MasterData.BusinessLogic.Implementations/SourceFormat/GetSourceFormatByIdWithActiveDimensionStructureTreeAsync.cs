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
        public async Task<SourceFormat> GetSourceFormatByIdWithActiveDimensionStructureTreeAsync(
            long sourceFormatId,
            CancellationToken cancellationToken)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                Check.AreNotEqual(sourceFormatId, 0);

                try
                {
                    SourceFormat result = await ctx.SourceFormats.AsNoTracking()
                       .FirstOrDefaultAsync(w => w.Id == sourceFormatId, cancellationToken)
                       .ConfigureAwait(false);

                    if (result == null)
                    {
                        return null;
                    }

                    DimensionStructureNode tree = await GetActiveDimensionStructureNodeTreeAsync(
                            result.SourceFormatDimensionStructureNode.DimensionStructureNode,
                            ctx)
                       .ConfigureAwait(false);

                    result.SourceFormatDimensionStructureNode.DimensionStructureNode = tree;

                    return result;
                }
                catch (Exception e)
                {
                    string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                                 $"{nameof(GetSourceFormatByIdWithActiveDimensionStructureTreeAsync)} " +
                                 $"operation failed. For further information see inner exception.";
                    throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
                }
            }
        }
    }
}
