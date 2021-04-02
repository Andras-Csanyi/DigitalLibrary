// <copyright file="AddSourceFormatAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using FluentValidation;

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

                    await _masterDataValidators.SourceFormatValidator.ValidateAsync(sourceFormat, o =>
                    {
                        o.IncludeRuleSets(SourceFormatValidatorRulesets.Add);
                        o.ThrowOnFailures();
                    }, cancellationToken).ConfigureAwait(false);

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