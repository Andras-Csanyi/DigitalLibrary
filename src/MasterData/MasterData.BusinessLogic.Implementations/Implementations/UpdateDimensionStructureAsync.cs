namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Ctx;

    using DomainModel.DomainModel;

    using Exceptions;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    using Validators.Validators;

    public partial class MasterDataBusinessLogic
    {
        public async Task<DimensionStructure> UpdateDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            try
            {
                if (dimensionStructure == null)
                {
                    throw new ArgumentNullException();
                }

                await _masterDataValidators.DimensionStructureValidator.ValidateAndThrowAsync(
                        dimensionStructure,
                        ruleSet: ValidatorRulesets.UpdateDimensionStructure)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    DimensionStructure toBeModified = await ctx.DimensionStructures.FindAsync(dimensionStructure.Id)
                       .ConfigureAwait(false);

                    if (toBeModified == null)
                    {
                        string msg = $"There is no {typeof(DimensionStructure)} " +
                            $"entity with id: {dimensionStructure.Id}";
                        throw new MasterDataBusinessLogicNoSuchDimensionStructureEntity(msg);
                    }

                    if (toBeModified.ParentDimensionStructureId != dimensionStructure.ParentDimensionStructureId)
                    {
                        DimensionStructure newParentDimStruct = await ctx.DimensionStructures
                           .FindAsync(dimensionStructure.ParentDimensionStructureId)
                           .ConfigureAwait(false);

                        if (newParentDimStruct == null)
                        {
                            string msg = $"There is no {typeof(DimensionStructure)} with " +
                                $"id: {dimensionStructure.ParentDimensionStructureId}, so " +
                                $"it can be added as parent dimension structure.";
                            throw new MasterDataBusinessLogicNoSuchDimensionStructureEntity(msg);
                        }
                    }

                    if (toBeModified.DimensionId != dimensionStructure.DimensionId)
                    {
                        Dimension newlyAttachedDimension = await ctx.Dimensions
                           .FindAsync(dimensionStructure.DimensionId)
                           .ConfigureAwait(false);

                        if (newlyAttachedDimension == null)
                        {
                            string msg = $"There is no {typeof(Dimension)} with " +
                                $"id {dimensionStructure.DimensionId}, so it cannot be added as " +
                                $"attached dimension to a dimension structure";
                            throw new MasterDataBusinessLogicNoSuchDimensionValueEntity(msg);
                        }
                    }

                    toBeModified.Name = dimensionStructure.Name;
                    toBeModified.Desc = dimensionStructure.Desc;
                    toBeModified.IsActive = dimensionStructure.IsActive;
                    toBeModified.ParentDimensionStructureId = dimensionStructure.ParentDimensionStructureId;
                    toBeModified.DimensionId = dimensionStructure.DimensionId;

                    ctx.Entry(toBeModified).State = EntityState.Modified;
                    await ctx.SaveChangesAsync().ConfigureAwait(false);

                    return toBeModified;
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicUpdateDimensionAsyncOperationException(e.Message, e);
            }
        }
    }
}