// <copyright file="GetSourceFormatAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatBusinessLogic
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