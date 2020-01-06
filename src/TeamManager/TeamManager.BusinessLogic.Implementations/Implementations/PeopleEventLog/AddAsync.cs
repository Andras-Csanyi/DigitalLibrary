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

    using Microsoft.EntityFrameworkCore.Storage;

    using Validators.Validators;

    public partial class PeopleEventLogBusinessLogic
    {
        public async Task<PeopleEventLog> AddAsync(PeopleEventLog peopleEventLog)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        await _peopleEventLogValidator.ValidateAndThrowAsync(
                                peopleEventLog,
                                ruleSet: ValidatorRulesets.Add)
                            .ConfigureAwait(false);

                        People people = await ctx.Peoples.FindAsync(peopleEventLog.PeopleId)
                            .ConfigureAwait(false);

                        if (people == null)
                        {
                            string msg = $"There is no people with id: {peopleEventLog.PeopleId}";
                            throw new PeopleDoesNotExistException(msg);
                        }

                        Event selectedEvent = await ctx.Events.FindAsync(peopleEventLog.EventId)
                            .ConfigureAwait(false);

                        if (selectedEvent == null)
                        {
                            string msg = $"No event with id: {peopleEventLog.EventId}";
                            throw new EventDoesNotExistException(msg);
                        }

                        PeopleEventLog newPeopleEventLog = new PeopleEventLog
                        {
                            Details = peopleEventLog.Details,
                            EventId = peopleEventLog.EventId,
                            PeopleId = peopleEventLog.PeopleId,
                            IsActive = 1
                        };
                        await _peopleEventLogValidator.ValidateAndThrowAsync(newPeopleEventLog)
                            .ConfigureAwait(false);
                        await ctx.PeopleEventLogs.AddAsync(newPeopleEventLog).ConfigureAwait(false);
                        await ctx.SaveChangesAsync().ConfigureAwait(false);

                        transaction.Commit();

                        return newPeopleEventLog;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();

                        throw new PeopleEventLogAddOperationException(e.Message, e);
                    }
                }
            }
        }
    }
}