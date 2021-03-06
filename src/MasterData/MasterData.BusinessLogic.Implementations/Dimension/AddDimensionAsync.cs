// <copyright file="AddDimensionAsync.cs" company="Andras Csanyi">
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

    public partial class MasterDataDimensionBusinessLogic
    {
        public async Task<Dimension> AddDimensionAsync(Dimension dimension)
        {
            try
            {
                Check.IsNotNull(dimension);

                await _masterDataValidators.DimensionValidator.ValidateAsync(dimension, o =>
                {
                    o.IncludeRuleSets(ValidatorRulesets.AddNewDimension);
                    o.ThrowOnFailures();
                }).ConfigureAwait(false);

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
