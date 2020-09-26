namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<DimensionStructure> GetDimensionStructureByNameWithSourceFormatsAsync(string name)
        {
            try
            {
                Check.NotNullOrEmptyOrWhitespace(name);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    return await ctx.DimensionStructures
                       .AsNoTracking()
                       .Include(p => p.SourceFormatsRootDimensionStructures)
                       .FirstOrDefaultAsync(p => p.Name.Equals(name))
                       .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                string msg = $"Error while executing {nameof(GetDimensionStructureByNameWithSourceFormatsAsync)} " +
                             $"method. For further info see inner exception.";
                throw new MasterDataBusinessLogicException(msg, e);
            }
        }
    }
}