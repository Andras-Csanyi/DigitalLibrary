namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Position
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Position;

    using Microsoft.EntityFrameworkCore;

    public partial class PositionBusinessLogic
    {
        public async Task<List<Position>> GetAllActiveAsync()
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    return await ctx.Positions
                        .Where(p => p.IsActive == 1)
                        .ToListAsync()
                        .ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new PositionGetAllActiveAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}