namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    public partial class MasterDataDimensionStructureBusinessLogic
    {
        /// <inheritdoc/>
        public async Task AddDimensionStructureToParentAsChildInSourceFormatAsync(
            long childId,
            long parentId,
            long sourceFormatId)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                using (IDbContextTransaction transaction = await ctx.Database.BeginTransactionAsync()
                   .ConfigureAwait(false))
                {
                    try
                    {
                        Check.AreNotEqual(childId, 0);
                        Check.AreNotEqual(parentId, 0);
                        Check.AreNotEqual(sourceFormatId, 0);
                        DimensionStructure dimensionStructure = await ctx.DimensionStructures.FindAsync(childId)
                           .ConfigureAwait(false);
                        SourceFormat sourceFormat = await ctx.SourceFormats.FindAsync(sourceFormatId)
                           .ConfigureAwait(false);

                        DimensionStructureNode node = await ctx.DimensionStructureNodes
                           .Where(w => w.SourceFormat.Id == sourceFormatId)
                           .FirstAsync(ww => ww.DimensionStructure.Id == parentId)
                           .ConfigureAwait(false);

                        DimensionStructureNode childNode = new DimensionStructureNode
                        {
                            DimensionStructure = dimensionStructure,
                            SourceFormat = sourceFormat,
                        };

                        await ctx.AddAsync(childNode).ConfigureAwait(false);
                        await ctx.SaveChangesAsync().ConfigureAwait(false);

                        node.ChildNodes.Add(childNode);
                        ctx.Entry(node).State = EntityState.Modified;
                        await ctx.SaveChangesAsync().ConfigureAwait(false);
                        await transaction.CommitAsync().ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync().ConfigureAwait(false);
                        string msg = $"{nameof(MasterDataDimensionStructureBusinessLogic)}." +
                                     $"{nameof(AddDimensionStructureToParentAsChildInSourceFormatAsync)} " +
                                     $"operation failed. For further info see inner exception.";
                        throw new MasterDataBusinessLogicDimensionStructureDatabaseOperationException(msg, e);
                    }
                }
        }
    }
}