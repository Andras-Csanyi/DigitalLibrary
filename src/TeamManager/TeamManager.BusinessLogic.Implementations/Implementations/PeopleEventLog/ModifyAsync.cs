namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.PeopleEventLog
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Event;
    using Exceptions.Exceptions.People;
    using Exceptions.Exceptions.PeopleEventLog;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    public partial class PeopleEventLogBusinessLogic
    {
        public async Task<PeopleEventLog> ModifyAsync(PeopleEventLog peopleEventLog)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        await _peopleEventLogValidator.ValidateAndThrowAsync(peopleEventLog)
                            .ConfigureAwait(false);

                        People involvedPeople = await ctx.Peoples.FindAsync(peopleEventLog.PeopleId)
                            .ConfigureAwait(false);

                        if (involvedPeople == null)
                        {
                            string msg =
                                $"TeamManager.Integration.Tests does not exist with id: {peopleEventLog.EventId}";
                            throw new PeopleDoesNotExistException(msg);
                        }

                        Event involvedEvent = await ctx.Events.FindAsync(peopleEventLog.EventId).ConfigureAwait(false);

                        if (involvedEvent == null)
                        {
                            string msg = $"There is no event with id: {peopleEventLog.EventId}";
                            throw new EventDoesNotExistException(msg);
                        }

                        PeopleEventLog peopleEventLogToBeModified = await ctx.PeopleEventLogs
                            .FindAsync(peopleEventLog.Id)
                            .ConfigureAwait(false);

                        if (peopleEventLogToBeModified == null)
                        {
                            string msg = $"No people event log with id: {peopleEventLog.Id}";
                            throw new PeopleEventLogEntryDoesNotExistsException(msg);
                        }

                        peopleEventLogToBeModified.Details = peopleEventLog.Details;
                        peopleEventLogToBeModified.EventId = peopleEventLog.EventId;
                        peopleEventLogToBeModified.PeopleId = peopleEventLog.PeopleId;
                        peopleEventLogToBeModified.IsActive = peopleEventLog.IsActive;

                        ctx.Entry(peopleEventLogToBeModified).State = EntityState.Modified;
                        await ctx.SaveChangesAsync().ConfigureAwait(false);

                        transaction.Commit();

                        return peopleEventLogToBeModified;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();

                        throw new PeopleEventLogModifyOperationException(e.Message, e);
                    }
                }
            }
        }
    }
}