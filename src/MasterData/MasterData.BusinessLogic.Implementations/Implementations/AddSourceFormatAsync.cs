// <copyright file="AddSourceFormatAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore.Storage;

    [SuppressMessage("ReSharper", "SA1601", Justification = "Reviewed.")]
    public partial class MasterDataBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<SourceFormat> AddSourceFormatAsync(
            SourceFormat sourceFormat)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                using (var transaction = await ctx.Database.BeginTransactionAsync().ConfigureAwait(false))
                {
                    try
                    {
                        Check.IsNotNull(sourceFormat);

                        long newSourceFormatId = await SaveSourceFormatAsync(sourceFormat, ctx)
                           .ConfigureAwait(false);

                        await ctx.SaveChangesAsync().ConfigureAwait(false);
                        await transaction.CommitAsync().ConfigureAwait(false);

                        SourceFormat query = new SourceFormat { Id = newSourceFormatId };
                        return await GetSourceFormatByIdAsync(query).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync().ConfigureAwait(false);
                        throw new MasterDataBusinessLogicAddSourceFormatAsyncOperationException(e.Message, e);
                    }
                }
            }
        }

        private async Task<long> SaveSourceFormatAsync(
            SourceFormat sourceFormat,
            MasterDataContext ctx)
        {
            Check.IsNotNull(sourceFormat);
            Check.IsNotNull(ctx);

            await _masterDataValidators.SourceFormatValidator.ValidateAndThrowAsync(
                    sourceFormat,
                    ruleSet: SourceFormatValidatorRulesets.Add)
               .ConfigureAwait(false);

            await ctx.SourceFormats.AddAsync(sourceFormat).ConfigureAwait(false);
            await ctx.SaveChangesAsync().ConfigureAwait(false);

            if (sourceFormat.RootDimensionStructure != null)
            {
                await SaveRootDimensionAsync(sourceFormat, ctx).ConfigureAwait(false);
            }

            return sourceFormat.Id;
        }

        private async Task SaveRootDimensionAsync(
            SourceFormat sourceFormat,
            MasterDataContext ctx)
        {
            Check.IsNotNull(sourceFormat);
            Check.IsNotNull(ctx);

            await _masterDataValidators.DimensionStructureValidator.ValidateAndThrowAsync(
                    sourceFormat.RootDimensionStructure,
                    ruleSet: DimensionStructureValidatorRulesets.Add)
               .ConfigureAwait(false);

            if (sourceFormat.RootDimensionStructure.ChildDimensionStructures.Any())
            {
                await SaveDimensionStructureTreeAsync(
                        sourceFormat.RootDimensionStructure.ChildDimensionStructures,
                        ctx)
                   .ConfigureAwait(false);
            }
        }

        private async Task SaveDimensionStructureTreeAsync(
            ICollection<DimensionStructure> childDimensionStructures,
            MasterDataContext ctx)
        {
        }
    }
}