// <copyright file="FindAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Menu
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Menu;
    using DigitalLibrary.ControlPanel.Ctx.Ctx;
    using DigitalLibrary.ControlPanel.Validators;

    using FluentValidation;

    public partial class MenuBusinessLogic
    {
        public async Task<DomainModel.Entities.Menu> FindAsync(DomainModel.Entities.Menu menu)
        {
            using (ControlPanelContext ctx = new ControlPanelContext(_dbContextOptions))
            {
                try
                {
                    if (menu == null)
                    {
                        string msg = $"Input null: {nameof(MenuBusinessLogic)}.{nameof(FindAsync)}";
                        throw new MenuNullInputException(msg);
                    }

                    await _menuValidator.ValidateAsync(menu, o =>
                    {
                        o.IncludeRuleSets(ValidatorRulesets.Find);
                        o.ThrowOnFailures();
                    }).ConfigureAwait(false);

                    return await ctx.Menus.FindAsync(menu.Id).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new MenuFindAsyncOperationException(e.Message, e.InnerException);
                }
            }
        }
    }
}