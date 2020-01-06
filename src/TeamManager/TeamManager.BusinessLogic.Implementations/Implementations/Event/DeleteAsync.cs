namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Event
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Event;

    using FluentValidation;

    using Validators.Validators;

    public partial class EventBusinessLogic
    {
        public async Task DeleteAsync(Event eventToBeDelete)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    if (eventToBeDelete == null)
                    {
                        string msg = $"Null input: {nameof(EventBusinessLogic)}.{nameof(DeleteAsync)}";
                        throw new EventInputNullException(msg);
                    }

                    await _eventValidator.ValidateAndThrowAsync(
                            eventToBeDelete,
                            ruleSet: ValidatorRulesets.Delete)
                        .ConfigureAwait(false);

                    Event selectedEvent = await ctx.Events.FindAsync(eventToBeDelete.Id).ConfigureAwait(false);
                    ctx.Remove(selectedEvent);

                    await ctx.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new EventDeleteAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}