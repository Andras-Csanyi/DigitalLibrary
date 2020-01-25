namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Exceptions;

    using Microsoft.EntityFrameworkCore;

    using Utils.Guards;

    public partial class MasterDataBusinessLogic
    {
        public async Task<Dimension> GetDimensionByIdAsync(long dimensionId)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    Check.AreNotEqual(dimensionId, 0);

                    Dimension result = await ctx.Dimensions
                       .Include(i => i.DimensionDimensionValues).ThenInclude(ti => ti.DimensionValue)
                       .FirstOrDefaultAsync(p => p.Id == dimensionId)
                       .ConfigureAwait(false);

                    return result;
                }
                catch (Exception e)
                {
                    throw new MasterDataBusinessLogicGetDimensionByIdAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}