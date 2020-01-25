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
        public async Task<Dimension> AddDimensionAsync(Dimension dimension)
        {
            try
            {
                Check.IsNotNull(dimension);

                await _masterDataValidators.DimensionValidator.ValidateAndThrowAsync(
                        dimension,
                        ruleSet: ValidatorRulesets.AddNewDimension)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    await ctx.Dimensions.AddAsync(dimension)
                       .ConfigureAwait(false);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);

                    return dimension;
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicAddDimensionAsyncOperationException(e.Message, e);
            }
        }
    }
}