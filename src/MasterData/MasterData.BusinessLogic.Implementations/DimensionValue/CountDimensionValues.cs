// <copyright file="CountDimensionValues.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionValue
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.Ctx;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataDimensionValueBusinessLogic
    {
        public async Task<long> CountDimensionValuesAsync()
        {
            using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            {
                try
                {
                    long res = await ctx.DimensionValues.LongCountAsync().ConfigureAwait(false);
                    return res;
                }
                catch (Exception e)
                {
                    throw new MasterDataBusinessLogicCountDimensionValuesAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}