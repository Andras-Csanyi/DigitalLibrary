// <copyright file="DeleteDimensionAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

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
        public async Task DeleteDimensionAsync(Dimension dimension)
        {
            try
            {
                Check.IsNotNull(dimension);
                await _masterDataValidators.DimensionValidator.ValidateAndThrowAsync(
                        dimension,
                        ruleSet: ValidatorRulesets.DeleteDimension)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    Dimension toBeDeleted = await ctx.Dimensions.FindAsync(dimension.Id)
                       .ConfigureAwait(false);
                    if (toBeDeleted == null)
                    {
                        string msg = $"There is no {nameof(Dimension)} " +
                            $"with id: {dimension}.";
                        throw new MasterDataBusinessLogicNoSuchDimensionEntity(msg);
                    }

                    ctx.Dimensions.Remove(toBeDeleted);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicDeleteDimensionAsyncOperationException(e.Message, e);
            }
        }
    }
}