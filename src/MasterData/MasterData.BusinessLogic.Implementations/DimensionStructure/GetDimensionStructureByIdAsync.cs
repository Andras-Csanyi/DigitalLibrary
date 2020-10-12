// <copyright file="GetDimensionStructureByIdAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Dimension;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.MasterData.Validators;
    using DigitalLibrary.Utils.Guards;

    using FluentValidation;

    public partial class MasterDataDimensionStructureBusinessLogic
    {
        /// <inheritdoc />
        public async Task<DimensionStructure> GetDimensionStructureByIdAsync(
            DimensionStructure dimensionStructure)
        {
            try
            {
                Check.IsNotNull(dimensionStructure);

                await _masterDataValidators.DimensionStructureValidator.ValidateAndThrowAsync(
                        dimensionStructure,
                        ruleSet: DimensionStructureValidatorRulesets.GetById)
                   .ConfigureAwait(false);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    DimensionStructure result = await ctx.DimensionStructures.FindAsync(dimensionStructure.Id)
                       .ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataDimensionBusinessLogic)}.{nameof(GetDimensionStructureByIdAsync)} " +
                             $"operation failed. For further info see inner exception.";
                throw new MasterDataBusinessLogicDimensionStructureDatabaseOperationException(msg, e);
            }
        }

        private async Task<DimensionStructure> GetDimensionStructureByIdWithChildrenAsync(
            long dimensionsStructureId)
        {
            try
            {
                Check.AreNotEqual(dimensionsStructureId, 0);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    DimensionStructure dimensionStructure = await ctx.DimensionStructures
                       .FindAsync(dimensionsStructureId)
                       .ConfigureAwait(false);

                    // dimensionStructure.ChildDimensionStructures = await GetDimensionStructureTreeAsync(
                    //         dimensionsStructureId,
                    //         ctx)
                    //    .ConfigureAwait(false);

                    return dimensionStructure;
                }
            }
            catch (Exception e)
            {
                string msg = $"Error happened while querying Dimensionstructure and its " +
                             $"DimensionStructure tree";
                throw new MasterDataBusinessLogicDatabaseOperationException(msg, e);
            }
        }

        private async Task<DimensionStructure> GetDimensionStructureByIdWithoutChildrenAsync(
            long dimensionStructureId)
        {
            // Check.AreNotEqual(dimensionStructureId, 0);
            //
            // using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            // {
            //     DimensionStructure result = await ctx.DimensionStructures
            //        .AsNoTracking()
            //        .Include(p => p.DimensionStructureDimensionStructures)
            //        .FirstOrDefaultAsync(k => k.Id == dimensionStructureId)
            //        .ConfigureAwait(false);
            //     return result;
            // }
            throw new NotImplementedException();
        }
    }
}