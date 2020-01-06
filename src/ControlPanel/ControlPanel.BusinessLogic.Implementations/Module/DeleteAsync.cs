namespace DigitalLibrary.IaC.ControlPanel.BusinessLogic.Implementations.Module
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Module;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    using Validators.Validators;

    public partial class ModuleBusinessLogic
    {
        public async Task DeleteAsync(Module toBeDelete)
        {
            using (ControlPanelContext ctx = new ControlPanelContext(_dbContextOptions))
            {
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        if (toBeDelete == null)
                        {
                            string msg = $"Null input: {nameof(ModuleBusinessLogic)}.{nameof(DeleteAsync)}";
                            throw new ModuleNullInputException(msg);
                        }

                        await _moduleValidator.ValidateAndThrowAsync(
                                toBeDelete,
                                ruleSet: ValidatorRulesets.Delete)
                            .ConfigureAwait(false);

                        List<Menu> menusToBeDelete = await ctx.Menus.Where(p => p.ModuleId == toBeDelete.Id)
                            .ToListAsync()
                            .ConfigureAwait(false);

                        if (menusToBeDelete.Any())
                        {
                            foreach (Menu menu in menusToBeDelete)
                            {
                                await _menuBusinessLogic.DeleteAsync(menu).ConfigureAwait(false);
                            }
                        }

                        ctx.Modules.Remove(toBeDelete);
                        await ctx.SaveChangesAsync().ConfigureAwait(false);

                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new ModuleDeleteOperationException(e.Message, e.InnerException);
                    }
                }
            }
        }
    }
}