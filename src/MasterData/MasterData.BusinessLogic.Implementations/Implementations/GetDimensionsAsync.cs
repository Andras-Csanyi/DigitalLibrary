namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Exceptions;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataBusinessLogic
    {
        public async Task<List<Dimension>> GetDimensionsAsync()
        {
            try
            {
                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    return await ctx.Dimensions
                       .ToListAsync()
                       .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicGetActiveDimensionsAsyncOperationException();
            }
        }
    }
}