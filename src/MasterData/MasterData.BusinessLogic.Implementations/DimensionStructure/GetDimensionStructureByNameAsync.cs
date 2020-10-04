// <copyright file="GetDimensionStructureByNameAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.DimensionStructure
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Exceptions;
    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataDimensionStructureBusinessLogic
    {
        public async Task<DimensionStructure> GetDimensionStructureByNameAsync(string name)
        {
            try
            {
                Check.NotNullOrEmptyOrWhitespace(name);

                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    DimensionStructure result = await ctx.DimensionStructures
                       .AsNoTracking()
                       .Where(q => q.Name == name)
                       .FirstOrDefaultAsync()
                       .ConfigureAwait(false);

                    return result;
                }
            }
            catch (Exception e)
            {
                string msg = $"Error happened while executing " +
                             $"{nameof(GetDimensionStructureByNameAsync)}";
                throw new MasterDataBusinessLogicDatabaseOperationException();
            }
        }
    }
}