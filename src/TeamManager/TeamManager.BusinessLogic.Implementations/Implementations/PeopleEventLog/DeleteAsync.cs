namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.PeopleEventLog
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.PeopleEventLog;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore.Storage;

    using Validators.Validators;

    public partial class PeopleEventLogBusinessLogic
    {
        public async Task DeleteAsync(PeopleEventLog peopleEventLog)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        await _peopleEventLogValidator.ValidateAndThrowAsync(peopleEventLog,
                                ruleSet: ValidatorRulesets.Delete)
                            .ConfigureAwait(false);

                        PeopleEventLog toBeDeleted = await ctx.PeopleEventLogs.FindAsync(peopleEventLog.Id)
                            .ConfigureAwait(false);

                        if (toBeDeleted == null)
                        {
                            string msg = $"There is no PeopleEventLog with id: {peopleEventLog.Id}";
                            throw new PeopleEventLogEntryDoesNotExistsException(msg);
                        }

                        ctx.PeopleEventLogs.Remove(toBeDeleted);
                        await ctx.SaveChangesAsync().ConfigureAwait(false);

                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new PeopleEventLogDeleteOperationException(e.Message, e);
                    }
                }
            }
        }
    }
}