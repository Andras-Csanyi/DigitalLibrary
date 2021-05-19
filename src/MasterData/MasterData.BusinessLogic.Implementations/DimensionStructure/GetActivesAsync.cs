namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataDimensionStructureBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<List<DimensionStructure>> GetActivesAsync(
            CancellationToken cancellationToken = default)
        {
            try
            {
                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    return await ctx.DimensionStructures
                       .Where(w => w.IsActive == 1)
                       .ToListAsync(cancellationToken)
                       .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataDimensionStructureBusinessLogic)}." +
                             $"{nameof(GetActivesAsync)} operation failed! " +
                             $"For further info see inner exception!";
                throw new MasterDataBusinessLogicDimensionStructureDatabaseOperationException(msg, e);
            }
        }
    }
}