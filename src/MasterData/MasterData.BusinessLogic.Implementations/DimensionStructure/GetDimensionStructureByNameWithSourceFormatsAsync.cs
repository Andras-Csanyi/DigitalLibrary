namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    public partial class MasterDataDimensionStructureBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<DimensionStructure> GetDimensionStructureByNameWithSourceFormatsAsync(string name)
        {
            // try
            // {
            //     Check.NotNullOrEmptyOrWhitespace(name);
            //
            //     using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            //     {
            //         return await ctx.DimensionStructures
            //            .AsNoTracking()
            //            .Include(p => p.SourceFormatsRootDimensionStructures)
            //            .FirstOrDefaultAsync(p => p.Name.Equals(name))
            //            .ConfigureAwait(false);
            //     }
            // }
            // catch (Exception e)
            // {
            //     string msg = $"Error while executing {nameof(GetDimensionStructureByNameWithSourceFormatsAsync)} " +
            //                  $"method. For further info see inner exception.";
            //     throw new MasterDataBusinessLogicException(msg, e);
            // }
            throw new NotImplementedException();
        }
    }
}