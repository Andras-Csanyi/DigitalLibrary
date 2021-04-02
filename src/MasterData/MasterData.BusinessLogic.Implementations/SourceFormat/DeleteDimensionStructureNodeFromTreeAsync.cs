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
            using (MasterDataContext ctx = new(_dbContextOptions))
                using (IDbContextTransaction transaction = await ctx.Database.BeginTransactionAsync(cancellationToken)
                   .ConfigureAwait(false))
                {
                    try
                    {
                        Check.AreNotEqual(id, 0);
                        Check.AreNotEqual(parentId, 0);
                        Check.AreNotEqual(sourceFormatId, 0);

                        DimensionStructureNode parent = await ctx.DimensionStructureNodes
                           .Include(i => i.ChildNodes)
                           .Where(p => p.Id == parentId)
                           .FirstOrDefaultAsync(
                                pp => pp.SourceFormatId == sourceFormatId,
                                cancellationToken)
                           .ConfigureAwait(false);

                        if (parent is null)
                        {
                            string msg = $"There is no parent {nameof(DimensionStructureNode)} with id: {parent} " +
                                         $"and {nameof(SourceFormat)}.Id: {sourceFormatId}";
                            throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg);
                        }

                        DimensionStructureNode toBeRemoved = await ctx.DimensionStructureNodes
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

                        DimensionStructureNode contains = parent.ChildNodes
                           .FirstOrDefault(c => c.Id == toBeRemoved.Id);

                        if (contains is null)
                        {
                            string msg = $"The parent with id: {parentId} doesn't have children with id: {id}";
                            throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg);
                        }

                        parent.ChildNodes.Remove(contains);
                        ctx.Entry(parent).State = EntityState.Modified;
                        await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                        ctx.Entry(toBeRemoved).State = EntityState.Deleted;
                        await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
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
    }
}