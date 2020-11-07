namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataDimensionStructureBusinessLogic
    {
        /// <inheritdoc />
        public async Task DeleteFromTree(
            long id,
            long sourceFormatId,
            CancellationToken cancellationToken = default)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    DimensionStructureNode node = await ctx.DimensionStructureNodes
                       .Where(sf => sf.SourceFormatId == sourceFormatId)
                       .FirstOrDefaultAsync(ds => ds.Id == id, cancellationToken: cancellationToken)
                       .ConfigureAwait(false);

                    ctx.DimensionStructureNodes.Remove(node);
                    await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    string msg = $"{nameof(MasterDataDimensionStructureBusinessLogic)}." +
                                 $"{nameof(DeleteFromTree)} operation failed. " +
                                 $"For further information see inner exception!";
                    throw new MasterDataBusinessLogicDimensionStructureDatabaseOperationException(msg, e);
                }
            }
        }
    }
}