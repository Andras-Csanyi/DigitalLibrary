using System;
using System.Threading.Tasks;

using DigitalLibrary.MasterData.Ctx.Ctx;
using DigitalLibrary.MasterData.DomainModel.DomainModel;

using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Implementations
{
    using Exceptions;

    public partial class MasterDataBusinessLogic
    {
        public async Task<Dimension> GetDimensionByIdAsync(long dimensionId)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    if (dimensionId == 0)
                    {
                        throw new MasterDataBusinessLogicArgumentNullException();
                    }

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