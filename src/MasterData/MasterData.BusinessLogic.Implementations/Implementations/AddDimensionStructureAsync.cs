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

    using Utils.Guards;

    using Validators;

    public partial class MasterDataBusinessLogic
    {
        public async Task<DimensionStructure> AddDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    Check.IsNotNull(dimensionStructure);

                    await _masterDataValidators.DimensionStructureValidator.ValidateAndThrowAsync(
                            dimensionStructure,
                            DimensionStructureValidatorRulesets.Add)
                       .ConfigureAwait(false);

                    DimensionStructure newDimensionStructure = new DimensionStructure
                    {
                        Name = dimensionStructure.Name,
                        Desc = dimensionStructure.Desc,
                        IsActive = dimensionStructure.IsActive,
                    };
                    await ctx.DimensionStructures.AddAsync(newDimensionStructure).ConfigureAwait(false);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);

                    return newDimensionStructure;
                }
                catch (Exception e)
                {
                    throw new MasterDataBusinessLogicAddDimensionStructureAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}