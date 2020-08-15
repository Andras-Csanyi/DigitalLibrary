// <copyright file="UpdateDimensionStructureAsync.cs" company="Andras Csanyi">
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

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataBusinessLogic
    {
        public async Task<DimensionStructure> UpdateDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            try
            {
                Check.IsNotNull(dimensionStructure);

                await _masterDataValidators.DimensionStructureValidator.ValidateAndThrowAsync(
                        dimensionStructure,
                        ruleSet: DimensionStructureValidatorRulesets.Update)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    DimensionStructure toBeModified = await ctx.DimensionStructures
                       .FindAsync(dimensionStructure.Id)
                       .ConfigureAwait(false);

                    string msg = $"There is no {typeof(DimensionStructure)} " +
                                 $"entity with id: {dimensionStructure.Id}";
                    Check.IsNotNull(toBeModified, msg);

                    toBeModified.Name = dimensionStructure.Name;
                    toBeModified.Desc = dimensionStructure.Desc;
                    toBeModified.IsActive = dimensionStructure.IsActive;

                    ctx.Entry(toBeModified).State = EntityState.Modified;
                    await ctx.SaveChangesAsync().ConfigureAwait(false);

                    return toBeModified;
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicUpdateDimensionStructureAsyncOperationException(e.Message, e);
            }
        }
    }
}