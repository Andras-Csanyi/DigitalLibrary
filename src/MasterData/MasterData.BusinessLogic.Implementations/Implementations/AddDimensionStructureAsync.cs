// <copyright file="AddDimensionStructureAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using FluentValidation;

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