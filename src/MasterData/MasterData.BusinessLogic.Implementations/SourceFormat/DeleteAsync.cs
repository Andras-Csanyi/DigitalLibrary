// <copyright file="DeleteSourceFormatAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc/>
        public async Task DeleteAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default)
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
                    SourceFormat result = await ctx.SourceFormats
                       .FirstOrDefaultAsync(
                            w => w.Id == sourceFormat.Id,
                            cancellationToken: cancellationToken)
                       .ConfigureAwait(false);

                    if (result != null)
                    {
                        ctx.SourceFormats.Remove(result);
                        await ctx.SaveChangesAsync(cancellationToken)
                           .ConfigureAwait(false);
                        return;
                    }

                    string msg = $"There is no {nameof(SourceFormat)} with id: {sourceFormat.Id}";
                    throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg);
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                             $"{nameof(DeleteAsync)} operation failed! " +
                             $"For further information see inner exception!";
                throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(e.Message, e);
            }
        }
    }
}