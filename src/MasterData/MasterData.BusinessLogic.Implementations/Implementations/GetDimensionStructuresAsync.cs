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
        public async Task<List<DimensionStructure>> GetDimensionStructuresAsync()
        {
            try
            {
                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    return await ctx.DimensionStructures
                       .Include(i => i.Dimension)
                       .Include(ii => ii.SourceFormats)
                       .ToListAsync()
                       .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicGetDimensionStructuresAsyncException(e.Message, e);
            }
        }
    }
}