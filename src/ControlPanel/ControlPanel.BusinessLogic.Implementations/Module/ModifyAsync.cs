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
    using Microsoft.EntityFrameworkCore.Storage;

    using Validators.Validators;

    public partial class ModuleBusinessLogic
    {
        public async Task<Module> ModifyAsync(Module modify)
        {
            using (ControlPanelContext ctx = new ControlPanelContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        if (modify == null)
                        {
                            string msg = $"Null input: {nameof(ModuleBusinessLogic)}.{nameof(ModifyAsync)}";
                            throw new ModuleNullInputException(msg);
                        }

                        await _moduleValidator.ValidateAndThrowAsync(
                                modify,
                                ruleSet: ValidatorRulesets.Modify)
                            .ConfigureAwait(false);

                        Module module = await ctx.Modules
                            .Include(p => p.Menus)
                            .FirstOrDefaultAsync(p => p.Id == modify.Id)
                            .ConfigureAwait(false);

                        if (module == null)
                        {
                            string msg = $"Module does not exists with id: {nameof(modify.Id)}";
                            throw new ModuleDoesNotExistsException(msg);
                        }

                        module.Description = modify.Description;
                        module.Name = modify.Name;
                        module.IsActive = modify.IsActive;
                        module.ModuleRoute = modify.ModuleRoute;

                        await _moduleValidator.ValidateAndThrowAsync(module,
                                ruleSet: ValidatorRulesets.Modify)
                            .ConfigureAwait(false);

                        ctx.Entry(module).State = EntityState.Modified;
                        await ctx.SaveChangesAsync().ConfigureAwait(false);

                        List<long> alreadyAttachedMenuIds = module.Menus.Select(p => p.Id).ToList();
                        List<long> modifiedListOfShouldBeAdded = modify.Menus.Select(p => p.Id).ToList();

                        List<long> diff = alreadyAttachedMenuIds.Except(modifiedListOfShouldBeAdded).ToList();

                        if (diff.Count > 0)
                        {
                            foreach (long l in diff)
                            {
                                Menu toBeDeleted = new Menu
                                {
                                    Id = l
                                };
                                await _menuBusinessLogic.DeleteAsync(toBeDeleted).ConfigureAwait(false);
                            }
                        }

                        transaction.Commit();

                        return module;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new ModuleModifyAsyncOperationException(e.Message, e.InnerException);
                    }
                }
            }
        }
    }
}