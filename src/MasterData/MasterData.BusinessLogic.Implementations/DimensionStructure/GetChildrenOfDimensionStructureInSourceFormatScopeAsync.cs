namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataDimensionStructureBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<List<DimensionStructure>> GetChildrenOfDimensionStructureInSourceFormatScopeAsync(
            long parentId,
            long sourceFormatId)
        {
            try
            {
                Check.AreNotEqual(parentId, 0);
                Check.AreNotEqual(sourceFormatId, 0);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    DimensionStructureNode dimensionStructureNode = await ctx.DimensionStructureNodes
                       .AsNoTracking()
                       .Include(i => i.ChildNodes).ThenInclude(ii => ii.DimensionStructure)
                       .Where(w => w.DimensionStructureId == parentId)
                       .FirstAsync(ww => ww.SourceFormatId == sourceFormatId)
                       .ConfigureAwait(false);

                    List<DimensionStructure> dimensionStructures = dimensionStructureNode.ChildNodes
                       .Select(e => e.DimensionStructure)
                       .ToList();

                    return dimensionStructures;
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataDimensionStructureBusinessLogic)}." +
                             $"{nameof(GetChildrenOfDimensionStructureInSourceFormatScopeAsync)} " +
                             $"operation failed. For further info see inner exception.";
                throw new MasterDataBusinessLogicDimensionStructureDatabaseOperationException(msg, e);
            }
        }
    }
}