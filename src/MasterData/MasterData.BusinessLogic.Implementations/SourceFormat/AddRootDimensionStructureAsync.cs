namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore.Storage;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc />
        public async Task AddRootDimensionStructureAsync(long sourceFormatId, long dimensionStructureId)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                using (IDbContextTransaction transaction = await ctx.Database.BeginTransactionAsync()
                   .ConfigureAwait(false))
                {
                    try
                    {
                        Check.AreNotEqual(sourceFormatId, 0);
                        Check.AreNotEqual(dimensionStructureId, 0);

                        SourceFormat sourceFormat = await ctx.SourceFormats.FindAsync(sourceFormatId)
                           .ConfigureAwait(false);

                        DimensionStructure dimensionStructure = await ctx.DimensionStructures
                           .FindAsync(dimensionStructureId)
                           .ConfigureAwait(false);

                        DimensionStructureNode node = new DimensionStructureNode
                        {
                            DimensionStructure = dimensionStructure,
                            SourceFormat = sourceFormat,
                        };

                        await ctx.AddAsync(node).ConfigureAwait(false);
                        await ctx.SaveChangesAsync().ConfigureAwait(false);

                        SourceFormatDimensionStructureNode sourceFormatDimensionStructureNode =
                            new SourceFormatDimensionStructureNode
                            {
                                DimensionStructureNode = node,
                                SourceFormat = sourceFormat,
                            };

                        await ctx.AddAsync(sourceFormatDimensionStructureNode).ConfigureAwait(false);
                        await ctx.SaveChangesAsync().ConfigureAwait(false);
                        await transaction.CommitAsync().ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync().ConfigureAwait(false);
                        string msg = $"{nameof(AddRootDimensionStructureAsync)} operation failed!" +
                                     $" For further information see inner exception.";
                        throw new MasterDataBusinessLogicDatabaseOperationException(msg, e);
                    }
                }
        }
    }
}