namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.People
{
    using System;

    using Ctx.Context;

    using Interfaces.Interfaces;

    using Microsoft.EntityFrameworkCore;

    using Validators.Validators;

    public partial class PeopleBusinessLogic : IPeopleBusinessLogic
    {
        private readonly DbContextOptions<TeamManagerContext> _dbContextOptions;

        private readonly PeopleValidator _peopleValidator;

        public PeopleBusinessLogic(DbContextOptions<TeamManagerContext> dbContextOptions,
                                   PeopleValidator peopleValidator)
        {
            _peopleValidator = peopleValidator ?? throw new ArgumentNullException(nameof(peopleValidator));
            _dbContextOptions = dbContextOptions ?? throw new ArgumentNullException(nameof(dbContextOptions));
        }
    }
}