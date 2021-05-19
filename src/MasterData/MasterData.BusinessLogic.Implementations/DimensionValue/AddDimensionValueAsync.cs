// <copyright file="AddDimensionValueAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionValue
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    public partial class MasterDataDimensionValueBusinessLogic
    {
        public async Task<DimensionValue> AddDimensionValueAsync(
            DimensionValue dimensionValue,
            long dimensionId)
        {
            try
            {
                Check.IsNotNull(dimensionValue);
                Check.AreNotEqual(dimensionId, 0);

                await _masterDataValidators.DimensionValueValidator.ValidateAsync(dimensionValue, o =>
                {
                    o.IncludeRuleSets(ValidatorRulesets.AddNewDimensionValue);
                    o.ThrowOnFailures();
                }).ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    using (IDbContextTransaction transaction = await ctx.Database.BeginTransactionAsync()
                       .ConfigureAwait(false))
                    {
                        try
                        {
                            // Check whether dimension exist
                            DomainModel.Dimension dimension = await ctx.Dimensions
                               .FindAsync(dimensionId)
                               .ConfigureAwait(true);

                            string msg = $"Dimension with Id {dimensionId} doesnt exists";
                            Check.IsNotNull(dimension, msg);

                            // check whether value already exist
                            DimensionValue doesDimensionValueExists = await ctx.DimensionValues
                               .FirstOrDefaultAsync(w => w.Value == dimensionValue.Value)
                               .ConfigureAwait(false);

                            if (doesDimensionValueExists != null)
                            {
                                // check whether dimension - dimension value pair exist
                                DimensionDimensionValue doesDimensionDimensionValueRelationExist = await ctx
                                   .DimensionDimensionValues
                                   .FirstOrDefaultAsync(p => p.DimensionId == dimension.Id
                                                          && p.DimensionValueId == doesDimensionValueExists.Id)
                                   .ConfigureAwait(false);

                                // if doesnt exists create one
                                if (doesDimensionDimensionValueRelationExist == null)
                                {
                                    DimensionDimensionValue dimensionDimensionValue = new DimensionDimensionValue
                                    {
                                        DimensionId = dimension.Id,
                                        DimensionValueId = doesDimensionValueExists.Id,
                                    };
                                    await ctx.DimensionDimensionValues.AddAsync(dimensionDimensionValue)
                                       .ConfigureAwait(false);
                                    await ctx.SaveChangesAsync().ConfigureAwait(false);
                                    await transaction.CommitAsync().ConfigureAwait(false);
                                    return doesDimensionValueExists;
                                }

                                // include all related entities
                                // return doesDimensionValueExists;
                                DimensionValue alreadyExistingDimensionValue =
                                    await GetDimensionValueWithRelatedEntities(
                                            dimensionValue.Value, ctx)
                                       .ConfigureAwait(false);
                                return alreadyExistingDimensionValue;
                            }

                            // create dimension value entry
                            DimensionValue newDimensionValue = new DimensionValue
                            {
                                Value = dimensionValue.Value,
                            };
                            await ctx.DimensionValues.AddAsync(newDimensionValue)
                               .ConfigureAwait(false);
                            await ctx.SaveChangesAsync().ConfigureAwait(false);

                            // create dimension - dimension value relation
                            DimensionDimensionValue newlyAddedDimensionValue = new DimensionDimensionValue
                            {
                                DimensionId = dimension.Id,
                                DimensionValueId = newDimensionValue.Id,
                            };
                            await ctx.DimensionDimensionValues.AddAsync(newlyAddedDimensionValue)
                               .ConfigureAwait(false);
                            await ctx.SaveChangesAsync().ConfigureAwait(false);

                            await transaction.CommitAsync().ConfigureAwait(false);
                            DimensionValue createdDimensionValue =
                                await GetDimensionValueWithRelatedEntities(dimensionValue.Value, ctx)
                                   .ConfigureAwait(false);
                            return createdDimensionValue;
                        }
                        catch (Exception e)
                        {
                            await transaction.RollbackAsync().ConfigureAwait(false);
                            throw;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicAddDimensionValueAsyncOperationException(e.Message, e);
            }
        }

        private async Task<DimensionValue> GetDimensionValueWithRelatedEntities(
            string dimensionValueValue,
            MasterDataContext ctx)
        {
            Check.IsNotNull(dimensionValueValue);
            Check.IsNotNull(ctx);

            DimensionValue res = await ctx.DimensionValues
               .Include(i => i.DimensionDimensionValues)
               .FirstOrDefaultAsync(p => p.Value == dimensionValueValue)
               .ConfigureAwait(false);
            return res;
        }
    }
}