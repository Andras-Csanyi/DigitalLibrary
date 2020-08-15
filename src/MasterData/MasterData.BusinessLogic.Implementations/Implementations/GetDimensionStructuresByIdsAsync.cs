// <copyright file="GetDimensionStructuresByIdsAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx;

    using DomainModel;

    using Exceptions;

    using Microsoft.EntityFrameworkCore;

    using Utils.Guards;

    using ViewModels;

    public partial class MasterDataBusinessLogic
    {
        public async Task<List<DimensionStructure>> GetDimensionStructuresByIdsAsync(
            DimensionStructureQueryObject dimensionStructureQueryObject)
        {
            try
            {
                Check.IsNotNull(dimensionStructureQueryObject);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    List<DimensionStructure> result = await ctx.DimensionStructures
                       .AsNoTracking()
                       .Where(p => dimensionStructureQueryObject.Ids.Contains(p.Id))
                       .ToListAsync()
                       .ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicGetDimensionStructuresByIdsAsyncOperationException(e.Message, e);
            }
        }
    }
}