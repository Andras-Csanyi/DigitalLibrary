using System;
using System.Threading.Tasks;
using DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Menu;
using DigitalLibrary.ControlPanel.Ctx.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Menu
{
    public partial class MenuBusinessLogic
    {
        public async Task<DomainModel.Entities.Menu> ModifyAsync(DomainModel.Entities.Menu modified)
        {
            using (ControlPanelContext ctx = new ControlPanelContext(_dbContextOptions))
            {
                try
                {
                    if (modified == null)
                    {
                        string msg = $"Null input: {nameof(MenuBusinessLogic)}.{nameof(ModifyAsync)}";
                        throw new MenuNullInputException(msg);
                    }

                    await _menuValidator.ValidateAndThrowAsync(modified).ConfigureAwait(false);

                    DomainModel.Entities.Menu toBeModified = await ctx.Menus.FindAsync(modified.Id).ConfigureAwait(false);

                    if (toBeModified == null)
                    {
                        string msg = $"There is no menu with id: {modified.Id}";
                        throw new MenuNoSuchMenuException(msg);
                    }

                    toBeModified.Description = modified.Description;
                    toBeModified.Name = modified.Name;
                    toBeModified.IsActive = modified.IsActive;
                    toBeModified.ModuleId = modified.ModuleId;
                    toBeModified.MenuRoute = modified.MenuRoute;

                    await _menuValidator.ValidateAndThrowAsync(toBeModified).ConfigureAwait(false);

                    ctx.Entry(toBeModified).State = EntityState.Modified;
                    await ctx.SaveChangesAsync().ConfigureAwait(false);

                    return toBeModified;
                }
                catch (Exception e)
                {
                    throw new MenuModifyOperationException(e.Message, e);
                }
            }
        }
    }
}