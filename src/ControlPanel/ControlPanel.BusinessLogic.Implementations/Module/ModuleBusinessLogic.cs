namespace DigitalLibrary.IaC.ControlPanel.BusinessLogic.Implementations.Module
{
    using System;

    using Ctx.Context;

    using Interfaces.Interfaces;

    using Microsoft.EntityFrameworkCore;

    using Validators.Validators;

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