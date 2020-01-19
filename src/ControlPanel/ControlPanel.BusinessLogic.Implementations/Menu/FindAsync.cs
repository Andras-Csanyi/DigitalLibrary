using System;
using System.Threading.Tasks;

using DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Menu;

using FluentValidation;

namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Menu
{
    using Ctx;

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