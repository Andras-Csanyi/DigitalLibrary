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
        public async Task<Event> AddAsync(Event newEvent)
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    if (newEvent == null)
                    {
                        string msg = $"Null input: {nameof(EventBusinessLogic)}.{nameof(AddAsync)}";
                        throw new EventInputNullException(msg);
                    }

                    await _eventValidator.ValidateAndThrowAsync(
                            newEvent,
                            ruleSet: ValidatorRulesets.Add)
                        .ConfigureAwait(false);

                    await ctx.Events.AddAsync(newEvent).ConfigureAwait(false);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);

                    return newEvent;
                }
                catch (Exception e)
                {
                    throw new EventAddAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}