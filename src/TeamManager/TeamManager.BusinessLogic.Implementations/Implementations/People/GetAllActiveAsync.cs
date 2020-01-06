namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.People;

    using Microsoft.EntityFrameworkCore;

    public partial class PeopleBusinessLogic
    {
        public async Task<List<People>> GetAllActiveAsync()
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    return await ctx.Peoples
                        .Where(p => p.IsActive == 1)
                        .ToListAsync()
                        .ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new PeopleGetAllActiveOperationException(e.Message, e);
                }
            }
        }
    }
}