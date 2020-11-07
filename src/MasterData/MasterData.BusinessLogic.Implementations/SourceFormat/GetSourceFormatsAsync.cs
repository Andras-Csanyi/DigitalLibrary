// <copyright file="GetSourceFormatAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        public async Task<List<SourceFormat>> GetSourceFormatsAsync(CancellationToken cancellationToken = default)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    List<SourceFormat> result = await ctx.SourceFormats
                       .AsNoTracking()
                       .ToListAsync(cancellationToken)
                       .ConfigureAwait(false);

                    return result;
                }
                catch (Exception e)
                {
                    string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                                 $"{nameof(GetSourceFormatsAsync)} operation failed! " +
                                 $"For further info see inner exception!";
                    throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
                }
            }
        }
    }
}