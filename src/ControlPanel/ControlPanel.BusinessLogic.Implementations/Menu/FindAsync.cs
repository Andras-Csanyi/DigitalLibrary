// <copyright file="FindAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Menu
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Ctx;

    using Exceptions.Menu;

    using FluentValidation;

    using Validators;

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

                    await _menuValidator.ValidateAndThrowAsync(
                            menu,
                            ruleSet: ValidatorRulesets.Find)
                       .ConfigureAwait(false);

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