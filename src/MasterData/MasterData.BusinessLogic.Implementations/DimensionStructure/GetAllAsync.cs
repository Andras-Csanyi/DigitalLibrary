namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataDimensionStructureBusinessLogic
    {
        public async Task<List<DimensionStructure>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    return await ctx.DimensionStructures.ToListAsync(cancellationToken)
                       .ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    string msg = $"{nameof(MasterDataDimensionStructureBusinessLogic)}." +
                                 $"{nameof(GetAllAsync)} operation failed! " +
                                 $"For further info see inner exception!";
                    throw new MasterDataBusinessLogicDimensionStructureDatabaseOperationException(msg, e);
                }
            }
        }
    }
}
