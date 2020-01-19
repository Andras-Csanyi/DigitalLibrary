using System;

using DigitalLibrary.ControlPanel.BusinessLogic.Interfaces.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Menu
{
    using Ctx;
    using Ctx.Ctx;

    using Validators;

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