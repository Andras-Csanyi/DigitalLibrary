namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Ctx.Ctx;

    using DomainModel.DomainModel;

    using Exceptions.Exceptions;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataBusinessLogic
    {
        public async Task<List<DimensionValue>> GetDimensionValuesAsync()
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    List<DimensionValue> result = await ctx.DimensionValues.ToListAsync();

                    return result;
                }
                catch (Exception e)
                {
                    throw new MasterDataBusinessLogicGetDimensionValuesAsyncOperationException();
                }
            }
        }
    }
}