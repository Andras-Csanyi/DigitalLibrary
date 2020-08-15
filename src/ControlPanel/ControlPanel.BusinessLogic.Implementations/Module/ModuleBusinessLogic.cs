// <copyright file="ModuleBusinessLogic.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Module
{
    using System;
    using DigitalLibrary.ControlPanel.BusinessLogic.Interfaces.Interfaces;
    using DigitalLibrary.ControlPanel.Ctx.Ctx;
    using DigitalLibrary.ControlPanel.Validators;
    using Microsoft.EntityFrameworkCore;

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