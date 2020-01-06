namespace DigitalLibrary.IaC.ControlPanel.BusinessLogic.Implementations.Module
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Module;

    using Microsoft.EntityFrameworkCore;

    public partial class ModuleBusinessLogic
    {
        public async Task<List<Module>> GetAllActiveAsync()
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