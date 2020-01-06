namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Event
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Event;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    using Validators.Validators;

    public partial class EventBusinessLogic
    {
        public async Task<Event> ModifyAsync(Event modifiedEvent)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        await _eventValidator.ValidateAndThrowAsync(
                                modifiedEvent,
                                ruleSet: ValidatorRulesets.Modify)
                            .ConfigureAwait(false);

                        Event willBeModified = await ctx.Events.FindAsync(modifiedEvent.Id).ConfigureAwait(false);

                        willBeModified.Name = modifiedEvent.Name;
                        willBeModified.IsActive = modifiedEvent.IsActive;

                        await _eventValidator.ValidateAndThrowAsync(
                                willBeModified,
                                ruleSet: ValidatorRulesets.Modify)
                            .ConfigureAwait(false);

                        ctx.Entry(willBeModified).State = EntityState.Modified;
                        await ctx.SaveChangesAsync().ConfigureAwait(false);

                        transaction.Commit();

                        return willBeModified;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new EventModifyOperationException(e.Message, e);
                    }
                }
            }
        }
    }
}