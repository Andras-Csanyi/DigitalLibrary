// <copyright file="AddSourceFormatAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore.Storage;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc />
        public async Task<SourceFormat> AddAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    Check.IsNotNull(sourceFormat);

                    await _masterDataValidators.SourceFormatValidator.ValidateAndThrowAsync(
                            sourceFormat,
                            ruleSet: SourceFormatValidatorRulesets.Add)
                       .ConfigureAwait(false);

                    await ctx.SourceFormats
                       .AddAsync(sourceFormat, cancellationToken)
                       .ConfigureAwait(false);
                    await ctx.SaveChangesAsync(cancellationToken)
                       .ConfigureAwait(false);

                    return sourceFormat;
                }
                catch (Exception e)
                {
                    string msg = $"Operation failed: {nameof(AddAsync)}. " +
                                 $"For further details see inner exception.";
                    throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
                }
            }
        }
    }
}