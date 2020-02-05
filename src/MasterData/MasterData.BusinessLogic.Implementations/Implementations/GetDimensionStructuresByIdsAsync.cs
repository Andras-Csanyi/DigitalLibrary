using DimensionStructureIds = MasterData.BusinessLogic.ViewModels.DimensionStructureIds;

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

    using Utils.Guards;

    public partial class MasterDataBusinessLogic
    {
        public async Task<List<DimensionStructure>> GetDimensionStructuresByIdsAsync(
            DimensionStructureIds dimensionStructureIds)
        {
            try
            {
                Check.IsNotNull(dimensionStructureIds);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    List<DimensionStructure> result = await ctx.DimensionStructures
                       .Include(p => p.ChildDimensionStructureDimensionStructures)
                       .Where(p => dimensionStructureIds.Ids.Contains(p.Id))
                       .ToListAsync()
                       .ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicGetDimensionStructuresByIdsAsyncOperationException(e.Message, e);
            }
        }
    }
}