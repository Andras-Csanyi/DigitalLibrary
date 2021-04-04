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