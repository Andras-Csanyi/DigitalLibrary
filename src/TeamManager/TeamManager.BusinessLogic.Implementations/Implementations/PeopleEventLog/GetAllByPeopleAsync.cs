namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.PeopleEventLog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.PeopleEventLog;

    using Microsoft.EntityFrameworkCore;

    public partial class PeopleEventLogBusinessLogic
    {
        public async Task<List<PeopleEventLog>> GetAllByPeople(long peopleId)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    if (peopleId == 0)
                    {
                        string msg = $"No people id provided";
                        throw new Exception(msg);
                    }

                    return await ctx.PeopleEventLogs
                        .Include(p => p.People)
                        .Include(p => p.Event)
                        .Where(p => p.PeopleId.Equals(peopleId))
                        .ToListAsync()
                        .ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new PeopleEventLogGetOperationException(e.Message, e);
                }
            }
        }
    }
}