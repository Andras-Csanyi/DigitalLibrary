// <copyright file="GetSourceFormatByIdAsync.cs" company="Andras Csanyi">
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

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc />
        public async Task<SourceFormat> GetByIdAsync(
            SourceFormat sourceFormat,
            CancellationToken cancellationToken = default)
        {
            Check.IsNotNull(sourceFormat);

            try
            {
                await _masterDataValidators.SourceFormatValidator.ValidateAsync(sourceFormat, o =>
                {
                    o.IncludeRuleSets(SourceFormatValidatorRulesets.GetById);
                    o.ThrowOnFailures();
                }, cancellationToken).ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    return await ctx.SourceFormats
                       .FirstOrDefaultAsync(w => w.Id == sourceFormat.Id, cancellationToken)
                       .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                    $"{nameof(GetByIdAsync)} operation failed! " +
                    $"For further information see inner exception!";
                throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
            }
        }
    }
}