namespace DigitalLibrary.IaC.ControlPanel.BusinessLogic.Implementations.Module
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Module;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore.Storage;

    using Validators.Validators;

    public partial class ModuleBusinessLogic
    {
        public async Task<Module> AddAsync(Module module)
        {
            using (ControlPanelContext ctx = new ControlPanelContext(_dbContextOptions))
            {
                using (IDbContextTransaction transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        if (module == null)
                        {
                            string msg = $"Null input: {nameof(ModuleBusinessLogic)}.{nameof(AddAsync)}";
                            throw new ModuleNullInputException(msg);
                        }

                        await _moduleValidator.ValidateAndThrowAsync(module,
                                ruleSet: ValidatorRulesets.AddNew)
                            .ConfigureAwait(false);

                        await ctx.Modules.AddAsync(module).ConfigureAwait(false);
                        await ctx.SaveChangesAsync().ConfigureAwait(false);

                        if (module.Menus.Any())
                        {
                            foreach (Menu moduleMenu in module.Menus)
                            {
                                await _menuBusinessLogic.AddAsync(moduleMenu).ConfigureAwait(false);
                            }
                        }

                        transaction.Commit();

                        return module;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new ModuleAddOperationException(e.Message, e.InnerException);
                    }
                }
            }
        }
    }
}