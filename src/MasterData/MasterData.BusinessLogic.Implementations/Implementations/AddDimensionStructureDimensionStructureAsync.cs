namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Exceptions;

    using FluentValidation;

    using Validators;

    public partial class MasterDataBusinessLogic
    {
        public async Task<DimensionStructureDimensionStructure> AddDimensionStructureDimensionStructureAsync(
            DimensionStructureDimensionStructure dimensionStructureDimensionStructure)
        {
            try
            {
                await _masterDataValidators.DimensionStructureDimensionStructureValidator
                   .ValidateAndThrowAsync(dimensionStructureDimensionStructure,
                        ruleSet: DimensionStructureDimensionStructureValidatorRulesets.Add)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    ctx.DimensionStructureDimensionStructures.Add(dimensionStructureDimensionStructure);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);
                    return dimensionStructureDimensionStructure;
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicAddDimensionStructureDimensionStructureAsyncOperationException(
                    e.Message,
                    e);
            }
        }
    }
}