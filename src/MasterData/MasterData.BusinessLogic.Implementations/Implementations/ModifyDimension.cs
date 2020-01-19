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
        public async Task<Dimension> ModifyDimensionAsync(long dimensionId, Dimension modifiedDimension)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    if (dimensionId == 0 || modifiedDimension == null)
                    {
                        string msg = $"Dimension id: {dimensionId} or modified dimension: {modifiedDimension} is null.";
                        throw new MasterDataBusinessLogicArgumentNullException(msg);
                    }

                    await _masterDataValidators.DimensionValidator.ValidateAndThrowAsync(
                            modifiedDimension,
                            ruleSet: ValidatorRulesets.ModifyDimension)
                       .ConfigureAwait(false);

                    Dimension toBeModified = await ctx.Dimensions.FindAsync(dimensionId).ConfigureAwait(false);

                    if (toBeModified == null)
                    {
                        string msg = $"No Dimension entity with id: {dimensionId}";
                        throw new MasterDataBusinessLogicNoSuchDimensionEntity(msg);
                    }

                    toBeModified.Name = modifiedDimension.Name;
                    toBeModified.Description = modifiedDimension.Description;
                    toBeModified.IsActive = modifiedDimension.IsActive;

                    ctx.Entry(toBeModified).State = EntityState.Modified;
                    await ctx.SaveChangesAsync().ConfigureAwait(false);

                    return toBeModified;
                }
                catch (Exception e)
                {
                    throw new MasterDataBusinessLogicModifyDimensionAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}