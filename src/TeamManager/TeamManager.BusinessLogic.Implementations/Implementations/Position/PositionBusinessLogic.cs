namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Position
{
    using System;

    using Ctx.Context;

    using Interfaces.Interfaces;

    using Microsoft.EntityFrameworkCore;

    using Validators.Validators;

    public partial class PositionBusinessLogic : IPositionBusinessLogic
    {
        private readonly DbContextOptions<TeamManagerContext> _dbContextOptions;

        private readonly PositionValidator _positionValidator;

        public PositionBusinessLogic(
            DbContextOptions<TeamManagerContext> dbContextOptions,
            PositionValidator positionValidator)
        {
            _positionValidator = positionValidator ?? throw new ArgumentNullException(nameof(positionValidator));
            _dbContextOptions = dbContextOptions ?? throw new ArgumentNullException(nameof(dbContextOptions));
        }
    }
}