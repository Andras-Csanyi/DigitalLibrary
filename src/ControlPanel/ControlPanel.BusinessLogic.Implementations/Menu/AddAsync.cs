// <copyright file="AddAsync.cs" company="Andras Csanyi">
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
        public async Task<DomainModel.Entities.Menu> AddAsync(DomainModel.Entities.Menu newMenu)
        {
            using (ControlPanelContext ctx = new ControlPanelContext(_dbContextOptions))
            {
                try
                {
                    if (newMenu == null)
                    {
                        string msg = $"null input: {nameof(MenuBusinessLogic)}.{nameof(AddAsync)}";
                        throw new MenuNullInputException(msg);
                    }

                    await _menuValidator.ValidateAndThrowAsync(
                            newMenu,
                            ruleSet: ValidatorRulesets.AddNew)
                       .ConfigureAwait(false);

                    await ctx.Menus.AddAsync(newMenu).ConfigureAwait(false);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);

                    return newMenu;
                }
                catch (Exception e)
                {
                    throw new MenuBusinessLogicAddAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}