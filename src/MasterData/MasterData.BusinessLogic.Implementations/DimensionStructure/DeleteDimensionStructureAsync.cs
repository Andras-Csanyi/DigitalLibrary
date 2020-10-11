// <copyright file="DeleteDimensionStructureAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    public partial class MasterDataDimensionStructureBusinessLogic
    {
        public async Task DeleteDimensionStructureAsync(DimensionStructure dimensionStructure)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction =
                    await ctx.Database.BeginTransactionAsync().ConfigureAwait(false))
                {
                    try
                    {
                        string guardMessage = $"{nameof(dimensionStructure)} is zero.";
                        Check.IsNotNull(dimensionStructure, guardMessage);

                        DimensionStructure toBeDeleted = await ctx.DimensionStructures
                           .FindAsync(dimensionStructure.Id)
                           .ConfigureAwait(false);

                        string msg = $"There is no {nameof(DimensionStructure)} entity " +
                                     $"with id: {dimensionStructure}.";
                        Check.IsNotNull(toBeDeleted, msg);

                        ctx.Entry(toBeDeleted).State = EntityState.Deleted;
                        await ctx.SaveChangesAsync().ConfigureAwait(false);
                        await transaction.CommitAsync().ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync().ConfigureAwait(false);
                        throw new MasterDataBusinessLogicDeleteDimensionStructureAsyncOperationException(
                            e.Message,
                            e);
                    }
                }
            }
        }
    }
}