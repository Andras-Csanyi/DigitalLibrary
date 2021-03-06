// <copyright file="FindAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Module
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Module;
    using DigitalLibrary.ControlPanel.Ctx.Ctx;

    using FluentValidation;

    using Microsoft.EntityFrameworkCore;

    public partial class ModuleBusinessLogic
    {
        public async Task<DomainModel.Entities.Module> FindAsync(DomainModel.Entities.Module module)
        {
            using (ControlPanelContext ctx = new ControlPanelContext(_dbContextOptions))
            {
                try
                {
                    if (module == null)
                    {
                        string msg = $"Null input: {nameof(ModuleBusinessLogic)}.{nameof(FindAsync)}";
                        throw new ModuleNullInputException(msg);
                    }

                    await _moduleValidator.ValidateAndThrowAsync(module).ConfigureAwait(false);

                    return await ctx.Modules
                       .Include(p => p.Menus)
                       .FirstOrDefaultAsync(p => p.Id == module.Id)
                       .ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new ModuleFindAsyncOperationException(e.Message, e.InnerException);
                }
            }
        }
    }
}
