namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Exceptions;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    using Validators;

    public partial class MasterDataBusinessLogic
    {
        public async Task<DimensionStructure> UpdateDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            try
            {
                if (dimensionStructure == null)
                {
                    throw new ArgumentNullException(nameof(dimensionStructure));
                }

                await _masterDataValidators.DimensionStructureValidator.ValidateAndThrowAsync(
                        dimensionStructure,
                        ruleSet: ValidatorRulesets.UpdateDimensionStructure)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    DimensionStructure toBeModified = await ctx.DimensionStructures
                       .FindAsync(dimensionStructure.Id)
                       .ConfigureAwait(false);

                    if (toBeModified == null)
                    {
                        string msg = $"There is no {typeof(DimensionStructure)} " +
                                     $"entity with id: {dimensionStructure.Id}";
                        throw new MasterDataBusinessLogicNoSuchDimensionStructureEntity(msg);
                    }

                    toBeModified.Name = dimensionStructure.Name;
                    toBeModified.Desc = dimensionStructure.Desc;
                    toBeModified.IsActive = dimensionStructure.IsActive;

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