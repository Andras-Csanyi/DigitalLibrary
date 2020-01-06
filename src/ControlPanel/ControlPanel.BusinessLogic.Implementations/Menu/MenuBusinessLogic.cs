namespace DigitalLibrary.IaC.ControlPanel.BusinessLogic.Implementations.Menu
{
    using System;

    using Ctx.Context;

    using Interfaces.Interfaces;

    using Microsoft.EntityFrameworkCore;

    using Validators.Validators;

    public partial class MenuBusinessLogic : IMenuBusinessLogic
    {
        private readonly DbContextOptions<ControlPanelContext> _dbContextOptions;

        private readonly MenuValidator _menuValidator;

        public MenuBusinessLogic(MenuValidator menuValidator, DbContextOptions<ControlPanelContext> dbContextOptions)
        {
            _menuValidator = menuValidator ?? throw new ArgumentNullException(nameof(menuValidator));
            _dbContextOptions = dbContextOptions ?? throw new ArgumentNullException(nameof(dbContextOptions));
        }
    }
}