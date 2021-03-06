namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Dimension;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<SourceFormat> GetSourceFormatByIdWithDimensionStructureNodeTreeAsync(
            SourceFormat querySourceFormat)
        {
            try
            {
                Check.IsNotNull(querySourceFormat);

                SourceFormat sourceFormat =
                    await GetSourceFormatByIdWithRootDimensionStructureNodeAsync(querySourceFormat)
                       .ConfigureAwait(false);

                if (sourceFormat.SourceFormatDimensionStructureNode != null)
                {
                    using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                    {
                        DimensionStructureNode tree = await GetDimensionStructureNodeTreeAsync(
                                sourceFormat.SourceFormatDimensionStructureNode.DimensionStructureNode,
                                ctx)
                           .ConfigureAwait(false);

                        sourceFormat.SourceFormatDimensionStructureNode.DimensionStructureNode = tree;
                    }
                }

                return sourceFormat;
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataDimensionBusinessLogic)}." +
                             $"{nameof(GetSourceFormatByIdWithDimensionStructureNodeTreeAsync)} " +
                             $"operation failed. For further info see inner exception.";
                throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg);
            }
        }

        private async Task<DimensionStructureNode> GetDimensionStructureNodeTreeAsync(
            DimensionStructureNode dimensionStructureNode,
            MasterDataContext ctx)
        {
            Check.IsNotNull(dimensionStructureNode);
            Check.IsNotNull(ctx);

            DimensionStructureNode node = await ctx.DimensionStructureNodes
               .AsNoTracking()
               .Include(i => i.ChildNodes)
               .Include(ii => ii.DimensionStructure)
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
