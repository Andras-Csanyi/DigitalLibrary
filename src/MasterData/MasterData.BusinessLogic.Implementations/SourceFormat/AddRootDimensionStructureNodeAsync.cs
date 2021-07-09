namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
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
        public async Task AddRootDimensionStructureNodeAsync(
            long sourceFormatId,
            long dimensionStructureNodeId,
            CancellationToken cancellationToken = default)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                using (IDbContextTransaction transaction = await ctx.Database
                   .BeginTransactionAsync(cancellationToken)
                   .ConfigureAwait(false))
                {
                    try
                    {
                        Check.AreNotEqual(sourceFormatId, 0);
                        Check.AreNotEqual(dimensionStructureNodeId, 0);

                        SourceFormat sourceFormat = await ctx.SourceFormats
                           .Include(root => root.SourceFormatDimensionStructureNode)
                           .FirstOrDefaultAsync(k => k.Id == sourceFormatId, cancellationToken)
                           .ConfigureAwait(false);

                        DimensionStructureNode dimensionStructureNode = await ctx.DimensionStructureNodes
                           .FirstOrDefaultAsync(k => k.Id == dimensionStructureNodeId, cancellationToken)
                           .ConfigureAwait(false);

                        if (sourceFormat is null)
                        {
                            string msg = $"No {nameof(SourceFormat)} with id: {sourceFormatId}.";
                            throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg);
                        }

                        if (dimensionStructureNode is null)
                        {
                            string msg = $"No {nameof(DimensionStructureNode)} with id: {dimensionStructureNodeId}.";
                            throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg);
                        }

                        if (sourceFormat.SourceFormatDimensionStructureNode is not null)
                        {
                            string msg = $"{nameof(SourceFormat)}(${sourceFormat.Id}) already has " +
                                         $"root ${nameof(DimensionStructureNode)}.";
                            throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg);
                        }

                        dimensionStructureNode.SourceFormat = sourceFormat;
                        ctx.Entry(dimensionStructureNode).State = EntityState.Modified;

                        SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode =
                            new SourceFormatDimensionStructureNode
                            {
                                DimensionStructureNode = dimensionStructureNode,
                                SourceFormat = sourceFormat,
                            };

                        await ctx.AddAsync(sourceFormatDimensionStructureNode, cancellationToken)
                           .ConfigureAwait(false);
                        await ctx.SaveChangesAsync(cancellationToken)
                           .ConfigureAwait(false);
                        await transaction.CommitAsync(cancellationToken)
                           .ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync(cancellationToken)
                           .ConfigureAwait(false);
                        string msg = $"{nameof(AddRootDimensionStructureNodeAsync)} operation failed!" +
                                     $" For further information see inner exception.";
                        throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
                    }
                }
        }
    }
}
