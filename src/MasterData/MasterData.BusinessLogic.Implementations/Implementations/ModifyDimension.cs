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
        public async Task<Dimension> ModifyDimensionAsync(Dimension dimension)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    if (dimension == null)
                    {
                        string msg = $"Dimension is null.";
                        throw new MasterDataBusinessLogicArgumentNullException(msg);
                    }

                    await _masterDataValidators.DimensionValidator.ValidateAndThrowAsync(
                            dimension,
                            ruleSet: ValidatorRulesets.UpdateDimension)
                       .ConfigureAwait(false);

                    Dimension toBeModified = await ctx.Dimensions.FindAsync(dimension.Id)
                       .ConfigureAwait(false);

                    if (toBeModified == null)
                    {
                        string msg = $"No Dimension entity with id: {dimension.Id}";
                        throw new MasterDataBusinessLogicNoSuchDimensionEntity(msg);
                    }

                    toBeModified.Name = dimension.Name;
                    toBeModified.Description = dimension.Description;
                    toBeModified.IsActive = dimension.IsActive;

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