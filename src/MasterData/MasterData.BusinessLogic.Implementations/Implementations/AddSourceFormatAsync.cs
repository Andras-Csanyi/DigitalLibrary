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

    [SuppressMessage("ReSharper", "SA1601", Justification = "Reviewed.")]
    public partial class MasterDataBusinessLogic
    {
        /// <inheritdoc />
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

                        SourceFormat result = await SaveSourceFormatAsync(sourceFormat, ctx)
                           .ConfigureAwait(false);

                        await ctx.SaveChangesAsync().ConfigureAwait(false);
                        await transaction.CommitAsync().ConfigureAwait(false);
                        return result;
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync().ConfigureAwait(false);
                        throw new MasterDataBusinessLogicAddSourceFormatAsyncOperationException(e.Message, e);
                    }
                }
            }
        }

        private async Task<SourceFormat> SaveSourceFormatAsync(
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

            DimensionStructure rootDimensionStructure = await CheckAndSaveRootDimensionAsync(sourceFormat, ctx)
               .ConfigureAwait(false);
            await CheckAndSaveDimensionStructureTreeAsync(
                sourceFormat,
                rootDimensionStructure,
                ctx).ConfigureAwait(false);

            return sourceFormat;
        }

        private async Task CheckAndSaveDimensionStructureTreeAsync(
            SourceFormat sourceFormat,
            DimensionStructure rootDimensionStructure,
            MasterDataContext ctx)
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

        private async Task SaveDimensionStructureTreeAsync(
            ICollection<DimensionStructure> childDimensionStructures,
            long parentDimensionStructureId,
            MasterDataContext ctx)
        {
            Check.IsNotNull(childDimensionStructures);
            Check.IsNotNull(ctx);
            Check.AreNotEqual(parentDimensionStructureId, 0);

            foreach (DimensionStructure childDimensionStructure in childDimensionStructures)
            {
            }
        }

        private async Task<DimensionStructure> CheckAndSaveRootDimensionAsync(
            SourceFormat sourceFormat,
            MasterDataContext ctx)
        {
            Check.IsNotNull(sourceFormat);
            // EF Core gives a temporary negative value to Id
            if (sourceFormat.RootDimensionStructure != null && sourceFormat.RootDimensionStructureId > 0)
            {
                // Add new relation to an existing DimensionStructure
                await AddSourceFormatWhereDimensionStructureIsARootDimensionStructure(
                        sourceFormat.RootDimensionStructureId,
                        sourceFormat.Id,
                        ctx)
                   .ConfigureAwait(false);
            }
            else if (sourceFormat.RootDimensionStructure != null && sourceFormat.RootDimensionStructureId <= 0)
            {
                // Create a new DimensionStructure
                DimensionStructure newDimensionStructure =
                    await CreateNewDimensionStructureAndAttachToSourceFormatAsRootDimensionStructure(
                            sourceFormat.RootDimensionStructure,
                            sourceFormat.RootDimensionStructureId,
                            ctx)
                       .ConfigureAwait(false);
            }

            long id = sourceFormat.RootDimensionStructureId ?? 0;
            DimensionStructureQueryObject query = new DimensionStructureQueryObject
            {
                GetDimensionsStructuredById = id,
            };
            DimensionStructure result = await GetDimensionStructureByIdAsync(query)
               .ConfigureAwait(false);

            return result;
        }

        private async Task<DimensionStructure>
            CreateNewDimensionStructureAndAttachToSourceFormatAsRootDimensionStructure(
                DimensionStructure newDimensionStructure,
                long? sourceFormatId,
                MasterDataContext ctx)
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

        private async Task AddSourceFormatWhereDimensionStructureIsARootDimensionStructure(
            long? sourceFormatRootDimensionStructureId,
            long sourceFormatId,
            MasterDataContext ctx)
        {
            Check.IsNotNull(sourceFormatRootDimensionStructureId);
            Check.AreNotEqual(sourceFormatRootDimensionStructureId, 0);
            Check.AreNotEqual(sourceFormatId, 0);
            Check.IsNotNull(ctx);

            SourceFormat querySourceFormat = new SourceFormat { Id = sourceFormatId };
            SourceFormat sourceFormat = await GetSourceFormatByIdAsync(querySourceFormat).ConfigureAwait(false);

            long id = sourceFormatRootDimensionStructureId ?? 0;
            DimensionStructureQueryObject queryDimensionStructure = new DimensionStructureQueryObject
            {
                GetDimensionsStructuredById = id,
            };
            DimensionStructure dimensionStructure = await GetDimensionStructureByIdAsync(queryDimensionStructure)
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
    }
}