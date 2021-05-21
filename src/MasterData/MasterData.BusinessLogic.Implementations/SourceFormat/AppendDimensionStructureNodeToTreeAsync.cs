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
        public async Task AppendDimensionStructureNodeToTreeAsync(
            long toBeAddedId,
            long parentId,
            long sourceFormatId,
            CancellationToken cancellationToken = default)
        {
            using (MasterDataContext _ctx = new(_dbContextOptions))
            {
                using (var transaction = await _ctx.Database.BeginTransactionAsync(cancellationToken)
                   .ConfigureAwait(false))
                {
                    try
                    {
                        Check.AreNotEqual(toBeAddedId, 0);
                        Check.AreNotEqual(parentId, 0);
                        Check.AreNotEqual(sourceFormatId, 0);

                        SourceFormat sourceFormat = await _ctx.SourceFormats
                           .FirstOrDefaultAsync(k => k.Id == sourceFormatId, cancellationToken)
                           .ConfigureAwait(false);

                        if (sourceFormat is null)
                        {
                            string msg = $"There is no {nameof(SourceFormat)} entity with Id: {sourceFormatId}";
                            throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg);
                        }

                        DimensionStructureNode toBeAdded = await _ctx.DimensionStructureNodes
                           .FirstOrDefaultAsync(w => w.Id == toBeAddedId, cancellationToken)
                           .ConfigureAwait(false);

                        if (toBeAdded is null)
                        {
                            string msg =
                                $"There is no {nameof(DimensionStructureNode)} with Id: {toBeAddedId} considered " +
                                $"as {nameof(toBeAdded)}.";
                            throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg);
                        }

                        DimensionStructureNode parentWithChildren = await _ctx.DimensionStructureNodes
                           .Include(i => i.ChildNodes)
                           .Where(sf => sf.SourceFormatId == sourceFormatId)
                           .FirstOrDefaultAsync(k => k.Id == parentId, cancellationToken)
                           .ConfigureAwait(false);

                        if (parentWithChildren is null)
                        {
                            string msg =
                                $"There is no {nameof(DimensionStructureNode)} with Id: {parentId} considered " +
                                $"as {nameof(parentWithChildren)}.";
                            throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg);
                        }

                        toBeAdded.SourceFormat = sourceFormat;
                        _ctx.Entry(toBeAdded).State = EntityState.Modified;
                        await _ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                        parentWithChildren.ChildNodes.Add(toBeAdded);
                        _ctx.Entry(parentWithChildren).State = EntityState.Modified;
                        await _ctx.SaveChangesAsync(cancellationToken)
                           .ConfigureAwait(false);
                        await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync(cancellationToken).ConfigureAwait(false);
                        string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                                     $"{nameof(AppendDimensionStructureNodeToTreeAsync)} operation has failed. " +
                                     $"For further information see inner exception.";
                        throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
                    }
                }
            }
        }
    }
}
