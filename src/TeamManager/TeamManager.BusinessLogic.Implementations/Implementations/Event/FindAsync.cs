namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Event
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Event;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore.Storage;

    using Validators.Validators;

    public partial class EventBusinessLogic
    {
        public async Task<Event> Find(Event toBeFound)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        await _eventValidator.ValidateAndThrowAsync(
                                toBeFound,
                                ruleSet: ValidatorRulesets.Find)
                            .ConfigureAwait(false);
                        Event result = await ctx.Events.FindAsync(toBeFound.Id).ConfigureAwait(false);

                        transaction.Commit();

                        return result;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new EventFindOperationException(e.Message, e);
                    }
                }
            }
        }
    }
}