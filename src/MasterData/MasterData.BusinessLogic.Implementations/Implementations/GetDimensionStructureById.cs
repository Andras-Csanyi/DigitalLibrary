namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Exceptions;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataBusinessLogic
    {
        public async Task<DimensionStructure> GetDimensionStructureById(long dimensionStructureId)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                if (dimensionStructureId == 0)
                {
                    throw new MasterDataBusinessLogicArgumentNullException();
                }

                DimensionStructure topLevel = await ctx.DimensionStructures
                   .Include(ii => ii.Dimension)
                   .FirstOrDefaultAsync(id => id.Id == dimensionStructureId)
                   .ConfigureAwait(false);

                topLevel.ChildDimensionStructures = await GetChildDimensionStructures(
                        topLevel,
                        ctx)
                   .ConfigureAwait(false);

                return topLevel;
            }
        }

        private async Task<List<DimensionStructure>> GetChildDimensionStructures(
            DimensionStructure parent,
            MasterDataContext ctx)
        {
            List<DimensionStructure> children = await ctx.DimensionStructures
               .Where(p => p.ParentDimensionStructureId == parent.Id)
               .ToListAsync()
               .ConfigureAwait(false);

            if (children.Any())
            {
                foreach (DimensionStructure dimensionStructure in children)
                {
                    dimensionStructure.ChildDimensionStructures = await GetChildDimensionStructures(
                            dimensionStructure,
                            ctx)
                       .ConfigureAwait(false);
                }
            }

            return children;
        }
    }
}