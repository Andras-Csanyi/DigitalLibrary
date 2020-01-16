namespace DigitalLibrary.IaC.MasterData.BusinessLogic.Implementations.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx.Ctx;

    using DomainModel.DomainModel;

    using Exceptions.Exceptions;

    using Interfaces.Interfaces;

    using Microsoft.EntityFrameworkCore;

    using Validators.Validators;

    public partial class MasterDataBusinessLogic
    {
        public async Task<List<Dimension>> GetActiveDimensionsAsync()
        {
            try
            {
                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    return await ctx.Dimensions
                        .Where(p => p.IsActive == 1)
                        .ToListAsync()
                        .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                throw new MasterDataBusinessLogicGetActiveDimensionsAsyncOperationException();
            }
        }
    }
}