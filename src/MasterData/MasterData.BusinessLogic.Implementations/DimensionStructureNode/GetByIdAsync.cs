namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructureNode
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataDimensionStructureNodeBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<DimensionStructureNode> GetByIdAsync(
            long id,
            CancellationToken cancellationToken = default)
        {
            try
            {
                Check.AreNotEqual(id, 0);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    DimensionStructureNode result = await ctx.DimensionStructureNodes
                       .FirstOrDefaultAsync(k => k.Id == id, cancellationToken)
                       .ConfigureAwait(false);

                    return result;
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataDimensionStructureNodeBusinessLogicException)}." +
                             $"{nameof(GetByIdAsync)} operation failed. For further info see inner exception.";
                throw new MasterDataDimensionStructureNodeBusinessLogicException(msg, e);
            }
        }
    }
}