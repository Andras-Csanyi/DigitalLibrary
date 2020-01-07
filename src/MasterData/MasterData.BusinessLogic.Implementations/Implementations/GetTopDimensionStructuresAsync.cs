namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx.Ctx;

    using DomainModel.DomainModel;

    using Exceptions.Exceptions;

    using Microsoft.EntityFrameworkCore;

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