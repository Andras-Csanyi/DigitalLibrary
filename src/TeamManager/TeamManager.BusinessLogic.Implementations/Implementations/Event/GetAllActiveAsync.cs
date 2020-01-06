namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Event
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Event;

    using Microsoft.EntityFrameworkCore;

    public partial class EventBusinessLogic
    {
        public async Task<List<Event>> GetAllActiveAsync()
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    return await ctx.Events
                        .Where(q => q.IsActive == 0)
                        .ToListAsync()
                        .ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new EventGetOperationException(e.Message, e);
                }
            }
        }
    }
}