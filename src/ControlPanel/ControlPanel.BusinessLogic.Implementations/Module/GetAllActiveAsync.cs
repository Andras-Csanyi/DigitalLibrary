// <copyright file="GetAllActiveAsync.cs" company="Andras Csanyi">
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

    using Microsoft.EntityFrameworkCore;

    public partial class ModuleBusinessLogic
    {
        public async Task<List<DomainModel.Entities.Module>> GetAllActiveAsync()
        {
            using (ControlPanelContext ctx = new ControlPanelContext(_dbContextOptions))
            {
                try
                {
                    return await ctx.Modules
                       .Include(p => p.Menus)
                       .Where(p => p.IsActive == 1)
                       .ToListAsync()
                       .ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new ModuleGetAllActiveAsyncOperationException(e.Message, e.InnerException);
                }
            }
        }
    }
}
