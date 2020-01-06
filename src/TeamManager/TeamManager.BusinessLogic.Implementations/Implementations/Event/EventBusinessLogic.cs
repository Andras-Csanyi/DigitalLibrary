namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Event
{
    using System;

    using Ctx.Context;

    using Interfaces.Interfaces;

    using Microsoft.EntityFrameworkCore;

    using Validators.Validators;

    public partial class EventBusinessLogic : IEventBusinessLogic
    {
        private readonly DbContextOptions<TeamManagerContext> _dbContextOptions;

        private readonly EventValidator _eventValidator;

        public EventBusinessLogic(DbContextOptions<TeamManagerContext> dbContextOptions, EventValidator eventValidator)
        {
            _eventValidator = eventValidator ?? throw new ArgumentNullException(nameof(eventValidator));
            _dbContextOptions = dbContextOptions ?? throw new ArgumentNullException(nameof(dbContextOptions));
        }
    }
}