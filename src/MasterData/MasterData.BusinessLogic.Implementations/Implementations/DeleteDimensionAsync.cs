namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Exceptions;

    using Microsoft.EntityFrameworkCore.Storage;

    public partial class MasterDataBusinessLogic
    {
        public async Task DeleteDimensionAsync(Dimension dimension)
        {
            try
            {
                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    Dimension toBeDeleted = await ctx.Dimensions.FindAsync(dimension.Id)
                       .ConfigureAwait(false);
                    if (toBeDeleted == null)
                    {
                        string msg = $"There is no {nameof(Dimension)} " +
                                     $"with id: {dimension}.";
                        throw new MasterDataBusinessLogicNoSuchDimensionEntity(msg);
                    }

                    ctx.Dimensions.Remove(toBeDeleted);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicDeleteDimensionAsyncOperationException(e.Message, e);
            }
        }
    }
}