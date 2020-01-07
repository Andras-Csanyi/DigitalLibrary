namespace DigitalLibrary.IaC.ControlPanel.BusinessLogic.Implementations.Menu
{
    using System;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Menu;

    using FluentValidation;

    using Validators.Validators;

    public partial class MenuBusinessLogic
    {
        public async Task<Menu> FindAsync(Menu menu)
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