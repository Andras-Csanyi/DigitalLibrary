// <copyright file="AddDimensionStructureAsync.cs" company="Andras Csanyi">
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

    public partial class MasterDataDimensionStructureBusinessLogic
    {
        /// <inheritdoc/>
        public async Task<DimensionStructure> AddAsync(
            DimensionStructure dimensionStructure,
            CancellationToken cancellationToken = default)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    Check.IsNotNull(dimensionStructure);

                    await _masterDataValidators.DimensionStructureValidator.ValidateAsync(dimensionStructure, o =>
                    {
                        o.IncludeRuleSets(DimensionStructureValidatorRulesets.AddAsync);
                        o.ThrowOnFailures();
                    }, cancellationToken).ConfigureAwait(false);

                    DimensionStructure newDimensionStructure = new DimensionStructure
                    {
                        Name = dimensionStructure.Name,
                        Desc = dimensionStructure.Desc,
                        IsActive = dimensionStructure.IsActive,
                    };
                    await ctx.DimensionStructures.AddAsync(
                            newDimensionStructure,
                            cancellationToken)
                       .ConfigureAwait(false);
                    await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                    return newDimensionStructure;
                }
                catch (Exception e)
                {
                    string msg = $"{nameof(MasterDataDimensionStructureBusinessLogic)}." +
                                 $"{nameof(AddAsync)} operation failed. For further info see inner exception.";
                    throw new MasterDataBusinessLogicDimensionStructureDatabaseOperationException(msg, e);
                }
            }
        }
    }
}