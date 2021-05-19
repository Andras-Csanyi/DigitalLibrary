// <copyright file="GetDimensionByIdAsync.cs" company="Andras Csanyi">
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
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataDimensionBusinessLogic
    {
        public async Task<Dimension> GetDimensionByIdAsync(long dimensionId)
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    Check.AreNotEqual(dimensionId, 0);

                    Dimension result = await ctx.Dimensions
                       .AsNoTracking()
                       .Include(i => i.DimensionDimensionValues)
                       .ThenInclude<Dimension, DimensionDimensionValue, DimensionValue>(ti => ti.DimensionValue)
                       .FirstOrDefaultAsync(p => p.Id == dimensionId)
                       .ConfigureAwait(false);

                    return result;
                }
                catch (Exception e)
                {
                    throw new MasterDataBusinessLogicGetDimensionByIdAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}
