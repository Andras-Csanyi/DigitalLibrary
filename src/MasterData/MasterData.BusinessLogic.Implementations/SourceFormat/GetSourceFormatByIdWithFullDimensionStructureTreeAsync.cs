// <copyright file="GetSourceFormatByIdWithFullDimensionStructureTreeAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Dimension;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc />
        public async Task<SourceFormat> GetSourceFormatByIdWithRootDimensionStructureAsync(
            SourceFormat querySourceFormat)
        {
            try
            {
                Check.IsNotNull(querySourceFormat);
                Check.AreNotEqual(querySourceFormat.Id, 0);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    SourceFormat sourceFormat = await ctx.SourceFormats
                       .Include(i => i.SourceFormatDimensionStructureNode)
                       .ThenInclude(ii => ii.DimensionStructureNode)
                       .AsNoTracking()
                       .FirstAsync(p => p.Id == querySourceFormat.Id)
                       .ConfigureAwait(false);

                    return sourceFormat;
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataDimensionBusinessLogic)}." +
                             $"{nameof(GetSourceFormatByIdWithRootDimensionStructureAsync)} operation failed. " +
                             $"For further details see inner exception.";
                throw new MasterDataBusinessLogicDatabaseOperationException(msg, e);
            }
        }
    }
}