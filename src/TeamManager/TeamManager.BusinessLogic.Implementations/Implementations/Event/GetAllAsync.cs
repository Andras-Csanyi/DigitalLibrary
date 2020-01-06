namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Event
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Event;

    using Microsoft.EntityFrameworkCore;

    public partial class EventBusinessLogic
    {
        public async Task<List<Event>> GetAllAsync()
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    return await ctx.Events.ToListAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new EventGetOperationException(e.Message, e);
                }
            }
        }
    }
}