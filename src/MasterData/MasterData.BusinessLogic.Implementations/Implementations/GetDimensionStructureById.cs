namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Microsoft.EntityFrameworkCore;

    using Utils.Guards;

    public partial class MasterDataBusinessLogic
    {
        public async Task<DimensionStructure> GetDimensionStructureById(long dimensionStructureId)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                Check.AreNotEqual(dimensionStructureId, 0);

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
            List<long> childIds = parent.ChildDimensionStructures.Select(p => p.Id).ToList();
            List<DimensionStructure> children = await ctx.DimensionStructures
               .Where(p => childIds.Contains(p.Id))
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