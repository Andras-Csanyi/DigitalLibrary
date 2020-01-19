namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx.Ctx;

    using DomainModel.DomainModel;

    using Exceptions;

    using Interfaces;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataBusinessLogic : IMasterDataBusinessLogic
    {
        public async Task<List<Dimension>> GetDimensionsWithoutStructureAsync()
        {
            try
            {
                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    return await ctx.Dimensions
                       .Where(n => n.DimensionStructure.Count == 0)
                       .ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicGetDimensionsWithoutStructureAsyncOperationException(
                    e.Message, e);
            }
        }
    }
}