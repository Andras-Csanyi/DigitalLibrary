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
        public async Task DeleteAsync(DomainModel.Entities.Menu toBeDeleted)
        {
            using (ControlPanelContext ctx = new ControlPanelContext(_dbContextOptions))
            {
                try
                {
                    if (toBeDeleted == null)
                    {
                        string msg = $"Null input: {nameof(MenuBusinessLogic)}.{nameof(DeleteAsync)}";
                        throw new MenuNullInputException(msg);
                    }

                    await _menuValidator.ValidateAndThrowAsync(
                            toBeDeleted,
                            ruleSet: ValidatorRulesets.Delete)
                       .ConfigureAwait(false);

                    ctx.Menus.Remove(toBeDeleted);
                    await ctx.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new MenuBusinessLogicDeleteAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}