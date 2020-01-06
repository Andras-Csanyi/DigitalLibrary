namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Title
{
    using System;

    using Ctx.Context;

    using Interfaces.Interfaces;

    using Microsoft.EntityFrameworkCore;

    using Validators.Validators;

    public partial class TitleBusinessLogic : ITitleBusinessLogic
    {
        private readonly DbContextOptions<TeamManagerContext> _dbContextOptions;

        private readonly TitleValidator _titleValidator;

        public TitleBusinessLogic(DbContextOptions<TeamManagerContext> dbContextOptions, TitleValidator titleValidator)
        {
            _titleValidator = titleValidator ?? throw new ArgumentNullException(nameof(titleValidator));
            _dbContextOptions = dbContextOptions ?? throw new ArgumentNullException(nameof(dbContextOptions));
        }
    }
}