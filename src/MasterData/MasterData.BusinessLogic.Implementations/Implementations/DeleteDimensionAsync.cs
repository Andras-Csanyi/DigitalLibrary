namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Ctx;

    using Microsoft.EntityFrameworkCore.Storage;

    public partial class MasterDataBusinessLogic
    {
        public async Task DeleteDimensionAsync(long dimensionId)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                using (IDbContextTransaction transactionAsync = await ctx.Database.BeginTransactionAsync()
                    .ConfigureAwait(false))
                {
                    try
                    {
                        // cases:
                        // if there is no value connected to it
                        // if there are values connected to it, and these values are not connected to other dimensions
                        // if connected values connected to other dimensions

                        await transactionAsync.CommitAsync().ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        await transactionAsync.RollbackAsync().ConfigureAwait(false);
                    }
                }
            }
        }
    }
}