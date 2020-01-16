using System;
using DigitalLibrary.ControlPanel.BusinessLogic.Interfaces.Interfaces;
using DigitalLibrary.ControlPanel.Ctx.Context;
using DigitalLibrary.ControlPanel.Validators.Validators;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Module
{
    public partial class ModuleBusinessLogic : IModuleBusinessLogic
    {
        private readonly DbContextOptions<ControlPanelContext> _dbContextOptions;

        private readonly IMenuBusinessLogic _menuBusinessLogic;

        private readonly ModuleValidator _moduleValidator;

        public ModuleBusinessLogic(
            IMenuBusinessLogic menuBusinessLogic,
            ModuleValidator moduleValidator,
            DbContextOptions<ControlPanelContext> dbContextOptions)
        {
            _moduleValidator = moduleValidator ?? throw new ArgumentNullException(nameof(moduleValidator));
            _dbContextOptions = dbContextOptions ?? throw new ArgumentNullException(nameof(dbContextOptions));
            _menuBusinessLogic = menuBusinessLogic ?? throw new ArgumentNullException(nameof(menuBusinessLogic));
        }
    }
}