namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Ctx;

    using DomainModel.DomainModel;

    using Exceptions.Exceptions;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    public partial class MasterDataBusinessLogic
    {
        public async Task DeleteDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = await ctx.Database.BeginTransactionAsync())
                {
                    try
                    {
                        if (dimensionStructure == null)
                        {
                            string msg = $"{nameof(dimensionStructure)} is zero.";
                            throw new MasterDataBusinessLogicArgumentNullException(msg);
                        }

                        DimensionStructure toBeDeleted = await ctx.DimensionStructures
                            .FindAsync(dimensionStructure.Id)
                            .ConfigureAwait(false);

                        if (toBeDeleted == null)
                        {
                            string msg = $"There is no {nameof(DimensionStructure)} entity " +
                                         $"with id: {dimensionStructure}.";
                            throw new MasterDataBusinessLogicNoSuchDimensionStructureEntity(msg);
                        }

                        ctx.Entry(toBeDeleted).State = EntityState.Deleted;
                        await ctx.SaveChangesAsync().ConfigureAwait(false);
                        await transaction.CommitAsync().ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync().ConfigureAwait(false);
                        throw new MasterDataBusinessLogicDeleteDimensionStructureAsyncOperationException(e.Message,
                            e);
                    }
                }
            }
        }
    }
}