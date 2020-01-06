namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Ctx;

    using Exceptions.Exceptions;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataBusinessLogic
    {
        public async Task<long> CountDimensionValuesAsync()
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    long res = await ctx.DimensionValues.LongCountAsync().ConfigureAwait(false);
                    return res;
                }
                catch (Exception e)
                {
                    throw new MasterDataBusinessLogicCountDimensionValuesAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}