// <copyright file="GetSourceFormatByIdAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        public async Task<SourceFormat> GetSourceFormatByIdAsync(SourceFormat sourceFormat)
        {
            // try
            // {
            //     await _masterDataValidators.SourceFormatValidator.ValidateAndThrowAsync(
            //             sourceFormat,
            //             SourceFormatValidatorRulesets.GetById)
            //        .ConfigureAwait(false);
            //
            //     using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            //     {
            //         SourceFormat result = await ctx.SourceFormats
            //            .AsNoTracking()
            //            .Include(p => p.DimensionStructureTreeRoot)
            //            .FirstOrDefaultAsync(id => id.Id == sourceFormat.Id)
            //            .ConfigureAwait(false);
            //         return result;
            //     }
            // }
            // catch (Exception e)
            // {
            //     throw new MasterDataBusinessLogicGetSourceFormatByIdAsyncOperationException(e.Message, e);
            // }
            throw new NotImplementedException();
        }
    }
}