namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.People
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.People;

    using Microsoft.EntityFrameworkCore;

    public partial class PeopleBusinessLogic
    {
        public async Task<List<People>> GetAllAsync()
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    return await ctx.Peoples
                        .ToListAsync()
                        .ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new PeopleGetAllOperationException(e.Message, e);
                }
            }
        }
    }
}