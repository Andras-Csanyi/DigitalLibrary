// <copyright file="DeleteDimensionStructureAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataDimensionStructureBusinessLogic
    {
        /// <inheritdoc />
        public async Task DeleteLogicallyAsync(DimensionStructure dimensionStructure)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    Check.IsNotNull(dimensionStructure);

                    DimensionStructure toBeDeleted = await ctx.DimensionStructures
                       .FindAsync(dimensionStructure.Id)
                       .ConfigureAwait(false);

                    string msg = $"There is no {nameof(DimensionStructure)} entity " +
                                 $"with id: {dimensionStructure}.";
                    Check.IsNotNull(toBeDeleted, msg);

                    toBeDeleted.IsActive = 0;
                    ctx.Entry(toBeDeleted).State = EntityState.Modified;
                    await ctx.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    string msg = $"{nameof(MasterDataDimensionStructureBusinessLogic)}." +
                                 $"{nameof(DeleteLogicallyAsync)} operation failed! " +
                                 $"For further info see inner exception!";
                    throw new MasterDataBusinessLogicDimensionStructureDatabaseOperationException(msg, e);
                }
            }
        }
    }
}