namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Exceptions;

    using Microsoft.EntityFrameworkCore;

    using Utils.Guards;

    public partial class MasterDataBusinessLogic
    {
        public async Task<DimensionStructure> GetDimensionStructureByNameAsync(string name)
        {
            try
            {
                Check.NotNullOrEmptyOrWhitespace(name);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    DimensionStructure result = await ctx.DimensionStructures
                       .AsNoTracking()
                       .Where(q => q.Name == name)
                       .FirstOrDefaultAsync()
                       .ConfigureAwait(false);

                    return result;
                }
            }
            catch (Exception e)
            {
                string msg = $"Error happened while executing " +
                             $"{nameof(GetDimensionStructureByNameAsync)}";
                throw new MasterDataBusinessLogicDatabaseOperationException();
            }
        }
    }
}