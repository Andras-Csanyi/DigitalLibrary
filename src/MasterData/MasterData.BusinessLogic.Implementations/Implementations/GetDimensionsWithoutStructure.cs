using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DigitalLibrary.MasterData.BusinessLogic.Interfaces.Interfaces;
using DigitalLibrary.MasterData.Ctx.Ctx;
using DigitalLibrary.MasterData.DomainModel.DomainModel;

using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.Implementations
{
    using Exceptions;

    public partial class MasterDataBusinessLogic : IMasterDataBusinessLogic
    {
        public async Task<List<Dimension>> GetDimensionsWithoutStructureAsync()
        {
            try
            {
                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    return await ctx.Dimensions
                       .Where(n => n.DimensionStructure.Count == 0)
                       .ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicGetDimensionsWithoutStructureAsyncOperationException(
                    e.Message, e);
            }
        }
    }
}