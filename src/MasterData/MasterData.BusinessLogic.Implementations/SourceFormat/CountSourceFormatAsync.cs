// <copyright file="CountSourceFormatAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.Ctx;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        public async Task<long> CountSourceFormatsAsync()
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    return await ctx.SourceFormats.LongCountAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new MasterDataBusinessLogicCountSourceFormatsAsync();
                }
            }
        }
    }
}
