namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.PeopleEventLog
{
    using System;

    using Ctx.Context;

    using Interfaces.Interfaces;

    using Microsoft.EntityFrameworkCore;

    using Validators.Validators;

    public partial class PeopleEventLogBusinessLogic : IPeopleEventLogBusinessLogic
    {
        private readonly DbContextOptions<TeamManagerContext> _dbContextOptions;

        private readonly PeopleEventLogValidator _peopleEventLogValidator;

        public PeopleEventLogBusinessLogic(
            DbContextOptions<TeamManagerContext> dbContextOptions,
            PeopleEventLogValidator peopleEventLogValidator)
        {
            _peopleEventLogValidator = peopleEventLogValidator ??
                                       throw new ArgumentNullException(nameof(peopleEventLogValidator));
            _dbContextOptions = dbContextOptions ?? throw new ArgumentNullException(nameof(dbContextOptions));
        }
    }
}