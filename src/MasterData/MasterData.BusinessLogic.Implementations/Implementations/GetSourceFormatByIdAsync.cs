namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Exceptions;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataBusinessLogic
    {
        public async Task<SourceFormat> GetSourceFormatByIdAsync(long sourceFormatId)
        {
            try
            {
                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    SourceFormat result = await ctx.SourceFormats
                       .Include(p => p.RootDimensionStructure)
                       .FirstOrDefaultAsync(id => id.Id == sourceFormatId)
                       .ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicGetSourceFormatByIdAsyncOperationException(e.Message, e);
            }
        }
    }
}