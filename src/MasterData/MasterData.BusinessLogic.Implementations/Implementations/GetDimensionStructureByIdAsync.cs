namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Exceptions;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    using Validators;

    public partial class MasterDataBusinessLogic
    {
        public async Task<DimensionStructure> GetDimensionStructureByIdAsync(DimensionStructure dimensionStructure)
        {
            try
            {
                await _masterDataValidators.DimensionStructureValidator.ValidateAndThrowAsync(
                        dimensionStructure,
                        ruleSet: DimensionStructureValidatorRulesets.GetById)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    DimensionStructure result = await ctx.DimensionStructures
                       .Include(p => p.DimensionStructureDimensionStructures)
                       .FirstOrDefaultAsync(k => k.Id == dimensionStructure.Id)
                       .ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicGetDimensionStructureByIdAsyncOperationException(e.Message, e);
            }
        }
    }
}