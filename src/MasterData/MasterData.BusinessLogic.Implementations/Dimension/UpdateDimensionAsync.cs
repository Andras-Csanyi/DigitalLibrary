// <copyright file="UpdateDimensionAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Dimension
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

    public partial class MasterDataDimensionBusinessLogic
    {
        public async Task<Dimension> UpdateDimensionAsync(Dimension dimension)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    string msg = $"{nameof(dimension)} is null.";
                    Check.IsNotNull(dimension, msg);

                    await _masterDataValidators.DimensionValidator.ValidateAsync(dimension, o =>
                    {
                        o.IncludeRuleSets(ValidatorRulesets.UpdateDimension);
                        o.ThrowOnFailures();
                    }).ConfigureAwait(false);

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
