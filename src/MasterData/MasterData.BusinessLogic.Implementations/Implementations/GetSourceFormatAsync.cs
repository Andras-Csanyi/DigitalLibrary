namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Exceptions;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataBusinessLogic
    {
        public async Task<List<SourceFormat>> GetSourceFormatsAsync()
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    List<SourceFormat> result = await ctx.SourceFormats
                       .ToListAsync()
                       .ConfigureAwait(false);

                    return result;
                }
                catch (Exception e)
                {
                    throw new MasterDataBusinessLogicGetSourceFormatsAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}