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