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
        public async Task DeleteDimensionStructureNodeFromTreeAsync(
            long id,
            long parentId,
            long sourceFormatId,
            CancellationToken cancellationToken = default)
        {
            DimensionStructureNode tree = null;

            using (MasterDataContext ctx = new(_dbContextOptions))
                using (IDbContextTransaction transaction = await ctx.Database.BeginTransactionAsync(cancellationToken)
                   .ConfigureAwait(false))
                {
                    try
                    {
                        Check.AreNotEqual(id, 0);
                        Check.AreNotEqual(parentId, 0);
                        Check.AreNotEqual(sourceFormatId, 0);

                        DimensionStructureNode toBeRemoved = await ctx.DimensionStructureNodes
                           .AsNoTracking()
                           .Include(i => i.ChildNodes)
                           .Where(p => p.Id == id)
                           .FirstOrDefaultAsync(
                                pp => pp.SourceFormatId == sourceFormatId,
                                cancellationToken)
                           .ConfigureAwait(false);

                        if (toBeRemoved is null)
                        {
                            string msg = $"There is no {nameof(DimensionStructureNode)} with id: {id} and " +
                                         $"{nameof(SourceFormat)}.Id: {sourceFormatId}";
                            throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg);
                        }

                        if (toBeRemoved.ChildNodes.Any())
                        {
                            DimensionStructureNode toBeRemovedWithoutChildNodes = await ctx.DimensionStructureNodes
                               .AsNoTracking()
                               .Where(p => p.Id == id)
                               .FirstOrDefaultAsync(
                                    pp => pp.SourceFormatId == sourceFormatId,
                                    cancellationToken)
                               .ConfigureAwait(false);

                            tree = await GetDimensionStructureNodeTreeAsync(
                                    toBeRemovedWithoutChildNodes,
                                    ctx)
                               .ConfigureAwait(false);

                            // if the removed entity has child entities, then the removing scope includes
                            // the entity itself see the following comment
                            await DeleteChildNodesOfDimensionStructureNodeAsync(
                                    tree,
                                    ctx,
                                    cancellationToken)
                               .ConfigureAwait(false);
                        }

                        // double check whether the entity to be removed is still in the database
                        // if it has child entities, then removal of the specified entity happened previously
                        DimensionStructureNode toBeRemovedRefresh = await ctx.DimensionStructureNodes
                           .FirstOrDefaultAsync(
                                k => k.Id == id,
                                cancellationToken)
                           .ConfigureAwait(false);

                        if (toBeRemovedRefresh != null)
                        {
                            ctx.Entry(toBeRemovedRefresh).State = EntityState.Deleted;
                            await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                        }

                        await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync(cancellationToken).ConfigureAwait(false);
                        string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}" +
                                     $".{nameof(DeleteDimensionStructureNodeFromTreeAsync)} failed. " +
                                     $"For further info see inner exception.";
                        throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
                    }
                }
        }

        private async Task DeleteChildNodesOfDimensionStructureNodeAsync(
            DimensionStructureNode tree,
            MasterDataContext ctx,
            CancellationToken cancellationToken)
        {
            try
            {
                if (tree.ChildNodes.Any())
                {
                    foreach (DimensionStructureNode treeChildNode in tree.ChildNodes)
                    {
                        await DeleteChildNodesOfDimensionStructureNodeAsync(
                                treeChildNode,
                                ctx,
                                cancellationToken)
                           .ConfigureAwait(false);
                    }
                }

                DimensionStructureNode dimensionStructureNode = await ctx.DimensionStructureNodes
                   .FirstAsync(
                        w => w.Id == tree.Id,
                        cancellationToken)
                   .ConfigureAwait(false);
                ctx.Entry(dimensionStructureNode).State = EntityState.Deleted;
                await ctx.SaveChangesAsync(cancellationToken)
                   .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                             $"{nameof(DeleteChildNodesOfDimensionStructureNodeAsync)} operation has failed. " +
                             $"For further information see inner exception.";
                throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
            }
        }
    }
}