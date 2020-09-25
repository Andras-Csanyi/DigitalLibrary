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
    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore.Storage;

    [SuppressMessage("ReSharper", "SA1601", Justification = "Reviewed.")]
    public partial class MasterDataBusinessLogic
    {
        /// <inheritdoc />
        public async Task<SourceFormat> AddSourceFormatAsync(
            SourceFormat sourceFormat)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = await ctx.Database.BeginTransactionAsync()
                   .ConfigureAwait(false))
                {
                    try
                    {
                        Check.IsNotNull(sourceFormat);
                        SourceFormat result = null;
                        if (sourceFormat.RootDimensionStructure != null)
                        {
                            result = await SaveSourceFormatWhenItHasRootDimensionStructure(
                                    sourceFormat,
                                    ctx)
                               .ConfigureAwait(false);
                        }
                        else
                        {
                            result = await SaveSourceFormatAsync(sourceFormat, ctx)
                               .ConfigureAwait(false);
                        }

                        if (result != null)
                        {
                            await ctx.SaveChangesAsync().ConfigureAwait(false);
                            await transaction.CommitAsync().ConfigureAwait(false);
                            return result;
                        }

                        throw new MasterDataBusinessLogicException($"Something went wrong." +
                                                                   $"{nameof(result)} which is " +
                                                                   $"{typeof(SourceFormat)} " +
                                                                   $"remained null.");
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync().ConfigureAwait(false);
                        throw new MasterDataBusinessLogicAddSourceFormatAsyncOperationException(e.Message, e);
                    }
                }
            }
        }

        private async Task<SourceFormat> SaveSourceFormatWhenItHasRootDimensionStructure(
            SourceFormat sourceFormat,
            MasterDataContext ctx)
        {
            Check.IsNotNull(sourceFormat);
            Check.IsNotNull(ctx);

            DimensionStructure dimensionStructure = await ctx.DimensionStructures
               .FindAsync(sourceFormat.RootDimensionStructureId)
               .ConfigureAwait(false);

            if (dimensionStructure == null)
            {
                return await SaveSourceFormatAsync(sourceFormat, ctx).ConfigureAwait(false);
            }

            sourceFormat.RootDimensionStructure = null;
            sourceFormat.RootDimensionStructure = dimensionStructure;
            sourceFormat.RootDimensionStructureId = null;
            sourceFormat.RootDimensionStructureId = dimensionStructure.Id;
            return await SaveSourceFormatAsync(sourceFormat, ctx).ConfigureAwait(false);
        }

        private async Task<SourceFormat> SaveSourceFormatAsync(
            SourceFormat sourceFormat,
            MasterDataContext ctx)
        {
            try
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
                    if (sourceFormat.RootDimensionStructure.ChildDimensionStructures.Any())
                    {
                        await CheckAndSaveDimensionStructureTreeAsync(
                            sourceFormat,
                            sourceFormat.RootDimensionStructure,
                            ctx).ConfigureAwait(false);
                    }
                }

                return sourceFormat;
            }
            catch (Exception e)
            {
                string msg = $"{nameof(SaveSourceFormatAsync)}";
                throw new MasterDataBusinessLogicException(msg, e);
            }
        }

        private async Task CheckAndSaveDimensionStructureTreeAsync(
            SourceFormat sourceFormat,
            DimensionStructure rootDimensionStructure,
            MasterDataContext ctx)
        {
            try
            {
                Check.IsNotNull(sourceFormat);
                Check.IsNotNull(rootDimensionStructure);
                Check.IsNotNull(ctx);

                if (sourceFormat.RootDimensionStructure.ChildDimensionStructures.Any())
                {
                    await SaveDimensionStructureTreeAsync(
                            sourceFormat.RootDimensionStructure.ChildDimensionStructures,
                            rootDimensionStructure.Id,
                            ctx)
                       .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(CheckAndSaveDimensionStructureTreeAsync)}";
                throw new MasterDataBusinessLogicException(msg, e);
            }
        }

        private async Task SaveDimensionStructureTreeAsync(
            ICollection<DimensionStructure> childDimensionStructures,
            long parentDimensionStructureId,
            MasterDataContext ctx)
        {
            try
            {
                Check.IsNotNull(childDimensionStructures);
                Check.IsNotNull(ctx);
                Check.AreNotEqual(parentDimensionStructureId, 0);

                foreach (DimensionStructure childDimensionStructure in childDimensionStructures)
                {
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(SaveDimensionStructureTreeAsync)}";
                throw new MasterDataBusinessLogicException(msg, e);
            }
        }

        private async Task<DimensionStructure> CheckAndSaveRootDimensionAsync(
            SourceFormat sourceFormat,
            MasterDataContext ctx)
        {
            try
            {
                Check.IsNotNull(sourceFormat);
                // EF Core gives a temporary negative value to Id
                if (sourceFormat.RootDimensionStructureId > 0)
                {
                    // Add new relation to an existing DimensionStructure
                    await AddSourceFormatWhereDimensionStructureIsARootDimensionStructure(
                            sourceFormat.RootDimensionStructureId,
                            sourceFormat.Id,
                            ctx)
                       .ConfigureAwait(false);
                }
                else if (sourceFormat.RootDimensionStructureId <= 0)
                {
                    // Create a new DimensionStructure
                    DimensionStructure newDimensionStructure =
                        await CreateNewDimensionStructureAndAttachToSourceFormatAsRootDimensionStructure(
                                sourceFormat.RootDimensionStructure,
                                sourceFormat.RootDimensionStructureId,
                                ctx)
                           .ConfigureAwait(false);
                }

                DimensionStructure result = await ctx.DimensionStructures
                   .FindAsync(sourceFormat.RootDimensionStructureId)
                   .ConfigureAwait(false);

                return result;
            }
            catch (Exception e)
            {
                string msg = $"{nameof(CheckAndSaveRootDimensionAsync)}";
                throw new MasterDataBusinessLogicException(msg, e);
            }
        }

        private async Task<DimensionStructure>
            CreateNewDimensionStructureAndAttachToSourceFormatAsRootDimensionStructure(
                DimensionStructure newDimensionStructure,
                long? sourceFormatId,
                MasterDataContext ctx)
        {
            try
            {
                Check.IsNotNull(newDimensionStructure);
                Check.IsNotNull(sourceFormatId);
                Check.AreNotEqual(sourceFormatId, 0);
                Check.IsNotNull(ctx);

                DimensionStructure result = await AddDimensionStructureAsync(newDimensionStructure)
                   .ConfigureAwait(false);

                long id = sourceFormatId ?? 0;
                SourceFormat querySourceFormat = new SourceFormat { Id = id };
                SourceFormat sourceFormat = await GetSourceFormatByIdAsync(querySourceFormat).ConfigureAwait(false);

                if (sourceFormat != null && result != null)
                {
                    result.SourceFormatsRootDimensionStructures.Add(sourceFormat);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);
                    return result;
                }

                string msg = $"Something went wrong in " +
                             $"{nameof(CreateNewDimensionStructureAndAttachToSourceFormatAsRootDimensionStructure)}";
                throw new MasterDataBusinessLogicException(msg);
            }
            catch (Exception e)
            {
                string msg = $"{nameof(CreateNewDimensionStructureAndAttachToSourceFormatAsRootDimensionStructure)}";
                throw new MasterDataBusinessLogicException(msg, e);
            }
        }

        private async Task AddSourceFormatWhereDimensionStructureIsARootDimensionStructure(
            long? sourceFormatRootDimensionStructureId,
            long sourceFormatId,
            MasterDataContext ctx)
        {
            try
            {
                Check.IsNotNull(sourceFormatRootDimensionStructureId);
                Check.AreNotEqual(sourceFormatRootDimensionStructureId, 0);
                Check.AreNotEqual(sourceFormatId, 0);
                Check.IsNotNull(ctx);

                SourceFormat sourceFormat = await ctx.SourceFormats.FindAsync(sourceFormatId)
                   .ConfigureAwait(false);

                DimensionStructure dimensionStructure = await ctx.DimensionStructures
                   .FindAsync(sourceFormatRootDimensionStructureId)
                   .ConfigureAwait(false);

                if (sourceFormat != null && dimensionStructure != null)
                {
                    dimensionStructure.SourceFormatsRootDimensionStructures.Add(sourceFormat);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);
                    return;
                }

                string msg = $"Either there is no source format with {sourceFormatId}, " +
                             $"or there is no dimension structure with id {sourceFormatRootDimensionStructureId}.";
                throw new MasterDataBusinessLogicException(msg);
            }
            catch (Exception e)
            {
                string msg = $"{nameof(AddSourceFormatWhereDimensionStructureIsARootDimensionStructure)}";
                throw new MasterDataBusinessLogicException(msg, e);
            }
        }
    }
}