namespace DigitalLibrary.IaC.ControlPanel.BusinessLogic.Implementations.Module
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Module;

    using Microsoft.EntityFrameworkCore;

    public partial class ModuleBusinessLogic
    {
        public async Task<List<Module>> GetAllAsync()
        {
            using (ControlPanelContext ctx = new ControlPanelContext(_dbContextOptions))
            {
                try
                {
                    return await ctx.Modules
                        .Include(p => p.Menus)
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