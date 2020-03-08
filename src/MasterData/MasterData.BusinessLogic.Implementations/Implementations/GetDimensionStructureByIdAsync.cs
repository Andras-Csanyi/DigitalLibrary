using DimensionStructureQueryObject = DigitalLibrary.MasterData.BusinessLogic.ViewModels.DimensionStructureQueryObject;

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Exceptions;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    using Utils.Guards;

    using Validators;

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
                    return await GetDimensionStructureByIdWithChildrenAsync(
                            dimensionStructureQueryObject.GetDimensionsStructuredById)
                       .ConfigureAwait(false);
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
            Check.AreNotEqual(dimensionsStructureId, 0);

            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                DimensionStructure dimensionStructureWithChildren = await ctx.DimensionStructures
                   .Include(i => i.ChildDimensionStructures)
                   .FirstOrDefaultAsync(id => id.Id == dimensionsStructureId)
                   .ConfigureAwait(false);

                DimensionStructure dimensionStructure = await ctx.DimensionStructures
                   .FindAsync(dimensionsStructureId)
                   .ConfigureAwait(false);

                if (dimensionStructureWithChildren.ChildDimensionStructures.Any())
                {
                    foreach (DimensionStructure dimStructure in dimensionStructure.ChildDimensionStructures)
                    {
                        DimensionStructure dimStructureWithChildren = await GetChildDimensionStructures(
                                dimStructure.Id)
                           .ConfigureAwait(false);
                        dimensionStructure.ChildDimensionStructures.Add(dimensionStructureWithChildren);
                    }
                }

                return dimensionStructure;
            }
        }

        private async Task<DimensionStructure> GetChildDimensionStructures(long dimStructureId)
        {
            Check.AreNotEqual(dimStructureId, 0);

            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
            }
        }


        private async Task<DimensionStructure> GetDimensionStructureByIdWithoutChildrenAsync(
            long dimensionStructureId)
        {
            Check.AreNotEqual(dimensionStructureId, 0);

            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                DimensionStructure result = await ctx.DimensionStructures
                   .Include(p => p.DimensionStructureDimensionStructures)
                   .FirstOrDefaultAsync(k => k.Id == dimensionStructureId)
                   .ConfigureAwait(false);
                return result;
            }
        }
    }
}