// <copyright file="GetDimensionStructuresAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.DomainModel;

    public partial class MasterDataDimensionStructureBusinessLogic
    {
        public async Task<List<DimensionStructure>> GetDimensionStructuresAsync()
        {
            // try
            // {
            //     using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
            //     {
            //         return await ctx.DimensionStructures
            //            .AsNoTracking()
            //            .Include(i => i.Dimension)
            //            .Include(ii => ii.SourceFormatsRootDimensionStructures)
            //            .ToListAsync()
            //            .ConfigureAwait(false);
            //     }
            // }
            // catch (Exception e)
            // {
            //     throw new MasterDataBusinessLogicGetDimensionStructuresAsyncException(e.Message, e);
            // }
            throw new NotImplementedException();
        }
    }
}