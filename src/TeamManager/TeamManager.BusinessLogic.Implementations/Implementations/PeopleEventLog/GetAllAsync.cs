namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.PeopleEventLog
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.PeopleEventLog;

    using Microsoft.EntityFrameworkCore;

    public partial class PeopleEventLogBusinessLogic
    {
        public async Task<List<PeopleEventLog>> GetAllAsync()
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    return await ctx.PeopleEventLogs.ToListAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new PeopleEventLogGetAllAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}