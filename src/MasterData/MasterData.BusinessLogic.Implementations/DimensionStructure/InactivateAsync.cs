// <copyright file="DeleteDimensionStructureAsync.cs" company="Andras Csanyi">
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
        public async Task InactivateAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    Check.IsNotNull(dimensionStructure);

                    await _masterDataValidators.DimensionStructureValidator.ValidateAsync(
                            dimensionStructure, options =>
                            {
                                options.IncludeRuleSets(DimensionStructureValidatorRulesets.Inactivate);
                                options.ThrowOnFailures();
                            }, cancellationToken)
                       .ConfigureAwait(false);

                    DimensionStructure toBeDeleted = await ctx.DimensionStructures.FirstOrDefaultAsync(
                            w => w.Id == dimensionStructure.Id,
                            cancellationToken)
                       .ConfigureAwait(false);

                    string msg = $"There is no {nameof(DimensionStructure)} entity " +
                                 $"with id: {dimensionStructure.Id}.";
                    Check.IsNotNull(toBeDeleted, msg);

                    toBeDeleted.IsActive = 0;
                    ctx.Entry(toBeDeleted).State = EntityState.Modified;
                    await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    string msg = $"{nameof(MasterDataDimensionStructureBusinessLogic)}." +
                                 $"{nameof(InactivateAsync)} operation failed! " +
                                 $"For further info see inner exception!";
                    throw new MasterDataBusinessLogicDimensionStructureDatabaseOperationException(msg, e);
                }
            }
        }
    }
}