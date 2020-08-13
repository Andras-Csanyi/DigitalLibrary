// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

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

    public partial class MasterDataBusinessLogic
    {
        public async Task<DimensionStructure> UpdateDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            try
            {
                Check.IsNotNull(dimensionStructure);

                await _masterDataValidators.DimensionStructureValidator.ValidateAndThrowAsync(
                        dimensionStructure,
                        ruleSet: DimensionStructureValidatorRulesets.Update)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    DimensionStructure toBeModified = await ctx.DimensionStructures
                       .FindAsync(dimensionStructure.Id)
                       .ConfigureAwait(false);

                    string msg = $"There is no {typeof(DimensionStructure)} " +
                        $"entity with id: {dimensionStructure.Id}";
                    Check.IsNotNull(toBeModified, msg);

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
                throw new MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException(e.Message, e);
            }
        }
    }
}