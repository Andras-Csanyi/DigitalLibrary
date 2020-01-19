using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DigitalLibrary.MasterData.Ctx.Ctx;
using DigitalLibrary.MasterData.DomainModel.DomainModel;

using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Implementations
{
    using Exceptions;

    public partial class MasterDataBusinessLogic
    {
        public async Task<List<DimensionStructure>> GetTopDimensionStructuresAsync()
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    List<DimensionStructure> result = await ctx.DimensionStructures
                       .Where(p => p.ParentDimensionStructureId == 0 || p.ParentDimensionStructureId == null)
                       .ToListAsync()
                       .ConfigureAwait(false);

                    return result;
                }
                catch (Exception e)
                {
                    throw new MasterDataBusinessLogicGetTopDimensionStructuresAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}