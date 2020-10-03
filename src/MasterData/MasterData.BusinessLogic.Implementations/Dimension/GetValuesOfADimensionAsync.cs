// <copyright file="GetValuesOfADimensionAsync.cs" company="Andras Csanyi">
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
        public async Task<Dimension> GetValuesOfADimensionAsync(long dimensionId)
        {
            try
            {
                string msg = $"{nameof(dimensionId)} is null";
                Check.AreNotEqual(dimensionId, 0, msg);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    Dimension dimension = await ctx.Dimensions
                       .Include(i => i.DimensionDimensionValues)
                       .ThenInclude(ti => ti.Dimension)
                       .Include(j => j.DimensionDimensionValues)
                       .ThenInclude(ji => ji.DimensionValue)
                       .FirstOrDefaultAsync(p => p.Id == dimensionId)
                       .ConfigureAwait(false);

                    return dimension;
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicGetDimensionValueAsyncOperationException(e.Message, e);
            }
        }
    }
}