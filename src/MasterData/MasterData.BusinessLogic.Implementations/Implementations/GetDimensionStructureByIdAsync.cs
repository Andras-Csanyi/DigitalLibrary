// <copyright file="GetDimensionStructureByIdAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Exceptions;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    using Utils.Guards;

    using Validators;

    using ViewModels;

    public partial class MasterDataBusinessLogic
    {
        public async Task<DimensionStructure> GetDimensionStructureByIdAsync(
            DimensionStructureQueryObject dimensionStructureQueryObject)
        {
            try
            {
                Check.IsNotNull(dimensionStructureQueryObject);

                await _masterDataValidators.DimensionStructureQueryObjectValidator.ValidateAndThrowAsync(
                        dimensionStructureQueryObject,
                        ruleSet: DimensionStructureQueryObjectValidatorRulesets.GetDimensionStructureByIdOperation)
                   .ConfigureAwait(false);

                if (dimensionStructureQueryObject.IncludeChildrenWhenGetDimensionStructureById)
                {
                    DimensionStructure withTree = await GetDimensionStructureByIdWithChildrenAsync(
                            dimensionStructureQueryObject.GetDimensionsStructuredById)
                       .ConfigureAwait(false);

                    return withTree;
                }

                return await GetDimensionStructureByIdWithoutChildrenAsync(
                        dimensionStructureQueryObject.GetDimensionsStructuredById)
                   .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicGetDimensionStructureByIdAsyncOperationException(e.Message, e);
            }
        }

        private async Task<DimensionStructure> GetDimensionStructureByIdWithChildrenAsync(
            long dimensionsStructureId)
        {
            try
            {
                Check.AreNotEqual(dimensionsStructureId, 0);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    DimensionStructure dimensionStructure = await ctx.DimensionStructures
                       .FindAsync(dimensionsStructureId)
                       .ConfigureAwait(false);

                    dimensionStructure.ChildDimensionStructures = await GetDimensionStructureTreeAsync(
                            dimensionsStructureId,
                            ctx)
                       .ConfigureAwait(false);

                    return dimensionStructure;
                }
            }
            catch (Exception e)
            {
                string msg = $"Error happened while querying Dimensionstructure and its " +
                    $"DimensionStructure tree";
                throw new MasterDataBusinessLogicDatabaseOperationException(msg, e);
            }
        }

        private async Task<DimensionStructure> GetDimensionStructureByIdWithoutChildrenAsync(
            long dimensionStructureId)
        {
            Check.AreNotEqual(dimensionStructureId, 0);

            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                DimensionStructure result = await ctx.DimensionStructures
                   .AsNoTracking()
                   .Include(p => p.DimensionStructureDimensionStructures)
                   .FirstOrDefaultAsync(k => k.Id == dimensionStructureId)
                   .ConfigureAwait(false);
                return result;
            }
        }
    }
}