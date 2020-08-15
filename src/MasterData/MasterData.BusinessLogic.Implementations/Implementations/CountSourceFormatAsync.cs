// <copyright file="CountSourceFormatAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Ctx;

    using Exceptions;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataBusinessLogic
    {
        public async Task<long> CountSourceFormatsAsync()
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    long res = await ctx.SourceFormats.LongCountAsync().ConfigureAwait(false);

                    return res;
                }
                catch (Exception e)
                {
                    throw new MasterDataBusinessLogicCountSourceFormatsAsync();
                }
            }
        }
    }
}