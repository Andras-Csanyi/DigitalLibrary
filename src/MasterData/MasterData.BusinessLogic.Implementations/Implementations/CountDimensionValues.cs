using System;
using System.Threading.Tasks;

using DigitalLibrary.MasterData.Ctx.Ctx;

using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Implementations
{
    using Exceptions;

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