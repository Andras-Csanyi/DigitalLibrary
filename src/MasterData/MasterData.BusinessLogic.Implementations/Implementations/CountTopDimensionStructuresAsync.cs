using System;
using System.Threading.Tasks;
using DigitalLibrary.MasterData.BusinessLogic.Exceptions.Exceptions;
using DigitalLibrary.MasterData.Ctx.Ctx;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Implementations
{
    public partial class MasterDataBusinessLogic
    {
        public async Task<long> CountTopDimensionStructuresAsync()
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    long res = await ctx.DimensionStructures
                        .LongCountAsync(w => w.ParentDimensionStructureId == null)
                        .ConfigureAwait(false);

                    return res;
                }
                catch (Exception e)
                {
                    throw new MasterDataBusinessLogicCountTopDimensionStructureAsync();
                }
            }
        }
    }
}