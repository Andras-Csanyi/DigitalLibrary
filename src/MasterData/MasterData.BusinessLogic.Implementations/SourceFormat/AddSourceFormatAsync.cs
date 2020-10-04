// <copyright file="AddSourceFormatAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore.Storage;

    [SuppressMessage("ReSharper", "SA1601", Justification = "Reviewed.")]
    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc />
        public async Task<SourceFormat> AddSourceFormatAsync(SourceFormat sourceFormat)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = await ctx.Database.BeginTransactionAsync()
                   .ConfigureAwait(false))
                {
                    try
                    {
                        Check.IsNotNull(sourceFormat);

                        await _masterDataValidators.SourceFormatValidator.ValidateAndThrowAsync(
                                sourceFormat,
                                ruleSet: SourceFormatValidatorRulesets.Add)
                           .ConfigureAwait(false);

                        await ctx.SourceFormats.AddAsync(sourceFormat).ConfigureAwait(false);
                        await ctx.SaveChangesAsync().ConfigureAwait(false);

                        await transaction.CommitAsync().ConfigureAwait(false);
                        return sourceFormat;
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync().ConfigureAwait(false);
                        string msg = $"Operation failed: {nameof(AddSourceFormatAsync)}. " +
                                     $"For further details see inner exception.";
                        throw new MasterDataBusinessLogicAddSourceFormatAsyncOperationException(msg, e);
                    }
                }
            }
        }
    }
}