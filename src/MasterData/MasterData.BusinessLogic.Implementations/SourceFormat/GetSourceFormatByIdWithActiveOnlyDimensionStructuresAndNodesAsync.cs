namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc />
        public async Task<SourceFormat> GetSourceFormatByIdWithActiveOnlyDimensionStructuresInTheTreeAsync(
            SourceFormat querySourceFormat)
        {
            try
            {
                Check.IsNotNull(querySourceFormat);
                SourceFormat result = await GetSourceFormatByIdWithRootDimensionStructureAsync(querySourceFormat)
                   .ConfigureAwait(false);

                if (result == null)
                {
                    return null;
                }

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    DimensionStructureNode tree = await GetActiveDimensionStructureNodeTreeAsync(
                            result.SourceFormatDimensionStructureNode.DimensionStructureNode,
                            ctx)
                       .ConfigureAwait(false);

                    result.SourceFormatDimensionStructureNode.DimensionStructureNode = tree;
                }

                return result;
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                             $"{nameof(GetSourceFormatByIdWithActiveOnlyDimensionStructuresInTheTreeAsync)} " +
                             $"operation failed. For further info see inner exception.";
                throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
            }
        }

        private async Task<DimensionStructureNode> GetActiveDimensionStructureNodeTreeAsync(
            DimensionStructureNode dimensionStructureNode,
            MasterDataContext ctx)
        {
            Check.IsNotNull(dimensionStructureNode);
            Check.IsNotNull(ctx);

            DimensionStructureNode node = await ctx.DimensionStructureNodes
               .AsNoTracking()
               .Include(i => i.ChildNodes)
               .Include(ii => ii.DimensionStructure)
               .Where(p => p.DimensionStructure.IsActive == 1)
               .FirstAsync(w => w.Id == dimensionStructureNode.Id)
               .ConfigureAwait(false);

            if (node.ChildNodes.Any())
            {
                foreach (DimensionStructureNode childNode in node.ChildNodes)
                {
                    DimensionStructureNode n = await GetDimensionStructureNodeTreeAsync(
                            childNode,
                            ctx)
                       .ConfigureAwait(false);
                    dimensionStructureNode.ChildNodes.Add(n);
                }
            }

            return dimensionStructureNode;
        }
    }
}