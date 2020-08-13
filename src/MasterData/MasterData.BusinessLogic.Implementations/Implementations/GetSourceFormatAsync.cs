// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Collections.Generic;
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
                       .AsNoTracking()
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