// <copyright file="UpdateDimensionStructureAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataDimensionStructureBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<DimensionStructure> UpdateAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default)
        {
            try
            {
                Check.IsNotNull(dimensionStructure);

                await _masterDataValidators.DimensionStructureValidator.ValidateAsync(dimensionStructure, o =>
                {
                    o.IncludeRuleSets(DimensionStructureValidatorRulesets.Update);
                    o.ThrowOnFailures();
                }, cancellationToken).ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    DimensionStructure toBeModified = await ctx.DimensionStructures
                       .FirstOrDefaultAsync(w => w.Id == dimensionStructure.Id, cancellationToken)
                       .ConfigureAwait(false);

                    string msg = $"There is no {typeof(DimensionStructure)} " +
                                 $"entity with id: {dimensionStructure.Id}";
                    Check.IsNotNull(toBeModified, msg);

                    toBeModified.Name = dimensionStructure.Name;
                    toBeModified.Desc = dimensionStructure.Desc;
                    toBeModified.IsActive = dimensionStructure.IsActive;

                    ctx.Entry(toBeModified).State = EntityState.Modified;
                    await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                    return toBeModified;
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataDimensionStructureBusinessLogic)}." +
                             $"{nameof(UpdateAsync)} operation failed. " +
                             $"For further information see inner exception.";
                throw new MasterDataBusinessLogicDimensionStructureDatabaseOperationException(msg, e);
            }
        }
    }
}
