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
        public async Task<Dimension> UpdateDimensionAsync(Dimension dimension)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    string msg = $"{nameof(dimension)} is null.";
                    Check.IsNotNull(dimension, msg);

                    await _masterDataValidators.DimensionValidator.ValidateAndThrowAsync(
                            dimension,
                            ruleSet: ValidatorRulesets.UpdateDimension)
                       .ConfigureAwait(false);

                    Dimension toBeModified = await ctx.Dimensions.FindAsync(dimension.Id)
                       .ConfigureAwait(false);

                    string tobeModifiedErrorMessage = $"No Dimension entity with id: {dimension.Id}";
                    Check.IsNotNull(toBeModified, tobeModifiedErrorMessage);

                    toBeModified.Name = dimension.Name;
                    toBeModified.Description = dimension.Description;
                    toBeModified.IsActive = dimension.IsActive;

                    ctx.Entry(toBeModified).State = EntityState.Modified;
                    await ctx.SaveChangesAsync().ConfigureAwait(false);

                    return toBeModified;
                }
                catch (Exception e)
                {
                    throw new MasterDataBusinessLogicUpdateDimensionAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}