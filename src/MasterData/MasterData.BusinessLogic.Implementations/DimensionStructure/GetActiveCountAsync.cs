namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataDimensionStructureBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<int> GetActiveCountAsync()
        {
            try
            {
                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    return await ctx.DimensionStructures.CountAsync(p => p.IsActive == 1).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataDimensionStructureBusinessLogic)}." +
                             $"{nameof(GetActiveCountAsync)} operation failed. " +
                             $"For further info see inner exception!";
                throw new MasterDataBusinessLogicDimensionStructureDatabaseOperationException(msg, e);
            }
        }
    }
}