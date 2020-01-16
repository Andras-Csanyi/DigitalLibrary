using System;
using DigitalLibrary.ControlPanel.BusinessLogic.Interfaces.Interfaces;
using DigitalLibrary.ControlPanel.Ctx.Context;
using DigitalLibrary.ControlPanel.Validators.Validators;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Menu
{
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