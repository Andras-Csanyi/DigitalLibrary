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
    using Microsoft.EntityFrameworkCore.Storage;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc/>
        public async Task DeleteRootDimensionStructureNodeAsync(
            long dimensionStructureNodeId,
            long sourceFormatId,
            CancellationToken cancellationToken = default)
        {
            Check.AreNotEqual(dimensionStructureNodeId, 0);
            Check.AreNotEqual(sourceFormatId, 0);

            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                using (IDbContextTransaction transaction = await ctx.Database
                   .BeginTransactionAsync(cancellationToken)
                   .ConfigureAwait(false))
                {
                    try
                    {
                        DimensionStructureNode rootNode = await ctx.DimensionStructureNodes
                           .AsNoTracking()
                           .Include(i => i.SourceFormatDimensionStructureNode)
                           .ThenInclude(ii => ii.SourceFormat)
                           .Include(iii => iii.ChildNodes)
                           .FirstOrDefaultAsync(
                                w => w.Id == dimensionStructureNodeId &&
                                     w.SourceFormatDimensionStructureNode.SourceFormatId == sourceFormatId,
                                cancellationToken)
                           .ConfigureAwait(false);

                        SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode = await ctx
                           .SourceFormatDimensionStructureNodes
                           .FirstOrDefaultAsync(
                                w => w.Id == rootNode.Id,
                                cancellationToken)
                           .ConfigureAwait(false);
                        ctx.Entry(sourceFormatDimensionStructureNode).State = EntityState.Deleted;
                        await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                        if (rootNode == null)
                        {
                            string msg = $"There is no {nameof(DimensionStructureNode)} with Id: " +
                                         $"{dimensionStructureNodeId}.";
                            throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg);
                        }

                        if (rootNode.ChildNodes.Any())
                        {
                            DimensionStructureNode rootNodeWithoutChildren = new DimensionStructureNode
                            {
                                Id = rootNode.Id,
                            };

                            DimensionStructureNode tree = await GetDimensionStructureNodeTreeAsync(
                                    rootNodeWithoutChildren, ctx)
                               .ConfigureAwait(false);
                            await DeleteChildNodesOfDimensionStructureNodeAsync(
                                    tree,
                                    ctx,
                                    cancellationToken)
                               .ConfigureAwait(false);
                        }

                        DimensionStructureNode refresh = await ctx.DimensionStructureNodes
                           .FirstOrDefaultAsync(
                                w => w.Id == dimensionStructureNodeId,
                                cancellationToken)
                           .ConfigureAwait(false);

                        if (refresh != null)
                        {
                            ctx.Entry(refresh).State = EntityState.Deleted;
                            await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                        }

                        await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync(cancellationToken).ConfigureAwait(false);
                        string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                                     $"{nameof(DeleteRootDimensionStructureNodeAsync)} operation has failed. " +
                                     $"For further information see inner exception.";
                        throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
                    }
                }
        }
    }
}