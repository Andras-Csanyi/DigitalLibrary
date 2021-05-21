// <copyright file="DeleteAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Module
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Module;
    using DigitalLibrary.ControlPanel.Ctx.Ctx;
    using DigitalLibrary.ControlPanel.Validators;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    public partial class ModuleBusinessLogic
    {
        public async Task DeleteAsync(DomainModel.Entities.Module toBeDelete)
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

                        await _moduleValidator.ValidateAsync(toBeDelete, o =>
                        {
                            o.IncludeRuleSets(ValidatorRulesets.Delete);
                            o.ThrowOnFailures();
                        }).ConfigureAwait(false);

                        List<DomainModel.Entities.Menu> menusToBeDelete = await ctx.Menus
                           .Where(p => p.ModuleId == toBeDelete.Id)
                           .ToListAsync()
                           .ConfigureAwait(false);

                        if (menusToBeDelete.Any())
                        {
                            foreach (DomainModel.Entities.Menu menu in menusToBeDelete)
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
