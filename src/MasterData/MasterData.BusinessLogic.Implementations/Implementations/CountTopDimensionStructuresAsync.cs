namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Ctx;

    using Exceptions;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataBusinessLogic
    {
        public async Task<long> CountSourceFormatAsync()
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