// <copyright file="DeleteSourceFormatAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using FluentValidation;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        public async Task DeleteSourceFormatAsync(SourceFormat sourceFormat)
        {
            try
            {
                Check.IsNotNull(sourceFormat);
                await _masterDataValidators.SourceFormatValidator.ValidateAndThrowAsync(
                        sourceFormat,
                        ruleSet: SourceFormatValidatorRulesets.Delete)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    SourceFormat result = await ctx.SourceFormats.FindAsync(sourceFormat.Id).ConfigureAwait(false);

                    string msg = $"Ther is no {nameof(SourceFormat)} with id: {sourceFormat.Id}";
                    Check.IsNotNull(result, msg);

                    ctx.SourceFormats.Remove(result);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicDeleteSourceFormatAsyncOperationException(e.Message, e);
            }
        }
    }
}