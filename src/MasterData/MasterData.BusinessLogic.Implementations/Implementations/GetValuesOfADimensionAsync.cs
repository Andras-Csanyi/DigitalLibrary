namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Ctx;

    using DomainModel.DomainModel;

    using Exceptions.Exceptions;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataBusinessLogic
    {
        public async Task<Dimension> GetValuesOfADimensionAsync(long dimensionId)
        {
            try
            {
                if (dimensionId == 0)
                {
                    throw new MasterDataBusinessLogicArgumentNullException(
                        $"{nameof(dimensionId)} is null");
                }

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    Dimension dimension = await ctx.Dimensions
                        .Include(i => i.DimensionDimensionValues)
                        .ThenInclude(ti => ti.Dimension)
                        .Include(j => j.DimensionDimensionValues)
                        .ThenInclude(ji => ji.DimensionValue)
                        .FirstOrDefaultAsync(p => p.Id == dimensionId)
                        .ConfigureAwait(false);

                    return dimension;
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicGetDimensionValueAsyncOperationException(e.Message, e);
            }
        }
    }
}