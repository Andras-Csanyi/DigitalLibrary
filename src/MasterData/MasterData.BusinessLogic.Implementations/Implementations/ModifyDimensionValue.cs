namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx.Ctx;

    using DomainModel.DomainModel;

    using Exceptions.Exceptions;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    using Validators.Validators;

    public partial class MasterDataBusinessLogic
    {
        public async Task<DimensionValue> ModifyDimensionValueAsync(
            long dimensionId,
            DimensionValue oldDimensionValue,
            DimensionValue newDimensionValue)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = await ctx.Database.BeginTransactionAsync()
                    .ConfigureAwait(false))
                {
                    try
                    {
                        if (dimensionId == 0 || oldDimensionValue == null || newDimensionValue == null)
                        {
                            string msg = $"{nameof(dimensionId)} or {oldDimensionValue} is null";
                            throw new MasterDataBusinessLogicArgumentNullException(msg);
                        }

                        await _masterDataValidators.DimensionValueValidator
                            .ValidateAndThrowAsync(oldDimensionValue,
                                ruleSet: ValidatorRulesets.ModifyDimensionValue);

                        Dimension dim = await ctx.Dimensions.FindAsync(dimensionId).ConfigureAwait(false);
                        if (dim == null)
                        {
                            string noDimErrMsg = $"There is no dimension with id: {dimensionId}";
                            throw new MasterDataBusinessLogicNoSuchDimensionEntity(noDimErrMsg);
                        }

                        DimensionValue dimVal = await ctx.DimensionValues.FindAsync(oldDimensionValue.Id)
                            .ConfigureAwait(false);
                        if (dimVal == null)
                        {
                            string dimValErrMsg = $"There is no dimension value with id: {oldDimensionValue.Id}";
                            throw new MasterDataBusinessLogicNoSuchDimensionValueEntity(dimValErrMsg);
                        }

                        // count how many dimension - dimension value relation exists
                        List<DimensionDimensionValue> countOfDimensionDimensionValueRelation = await ctx
                            .DimensionDimensionValues
                            .Where(p => p.DimensionValueId == oldDimensionValue.Id
                                        && p.DimensionId != dimensionId)
                            .ToListAsync().ConfigureAwait(false);

                        if (countOfDimensionDimensionValueRelation.Any())
                        {
                            // If multiple dimensions references to the given dimension value
                            // then we are going to create a new dimension value and we are going to modify
                            // the dimension - dimension value reference to that
                            DimensionValue modifiedButNewDimensionValue = new DimensionValue
                            {
                                Value = newDimensionValue.Value
                            };
                            await ctx.DimensionValues.AddAsync(modifiedButNewDimensionValue).ConfigureAwait(false);
                            await ctx.SaveChangesAsync().ConfigureAwait(false);

                            DimensionDimensionValue theOneGoingToBeModified = await ctx.DimensionDimensionValues
                                .FirstOrDefaultAsync(p => p.DimensionId == dimensionId
                                                          && p.DimensionValueId == oldDimensionValue.Id)
                                .ConfigureAwait(false);
                            if (theOneGoingToBeModified == null)
                            {
                                string msg = $"There is no DimensionDimensionValue entity with " +
                                             $"dimension id: {dimensionId}, and" +
                                             $"dimension value id: {oldDimensionValue.Id}!";
                                throw new MasterDataBusinessLogicNoSuchDimensionDimensionValueEntity(msg);
                            }

                            theOneGoingToBeModified.DimensionValueId = modifiedButNewDimensionValue.Id;
                            ctx.Entry(theOneGoingToBeModified).State = EntityState.Modified;
                            await ctx.SaveChangesAsync().ConfigureAwait(false);

                            await transaction.CommitAsync().ConfigureAwait(false);

                            DimensionValue modifiedResult = await ctx.DimensionValues.FirstOrDefaultAsync(
                                p => p.Id == modifiedButNewDimensionValue.Id);
                            return modifiedResult;
                        }

                        DimensionValue dimValToBeModified = await ctx.DimensionValues.FirstOrDefaultAsync(
                            p => p.Id == oldDimensionValue.Id).ConfigureAwait(false);

                        if (dimValToBeModified == null)
                        {
                            string erMsg = $"There is no dimension value with id: {oldDimensionValue.Id}";
                            throw new MasterDataBusinessLogicNoSuchDimensionValueEntity(erMsg);
                        }

                        dimValToBeModified.Value = newDimensionValue.Value;
                        ctx.Entry(dimValToBeModified).State = EntityState.Modified;
                        await ctx.SaveChangesAsync().ConfigureAwait(false);
                        await transaction.CommitAsync().ConfigureAwait(false);
                        return dimValToBeModified;
                    }
                    catch (Exception e)
                    {
                        await transaction.CommitAsync().ConfigureAwait(false);
                        throw new MasterDataBusinessLogicModifyDimensionValueAsyncOperationException(
                            e.Message, e);
                    }
                }
            }
        }
    }
}