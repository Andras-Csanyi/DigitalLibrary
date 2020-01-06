namespace DigitalLibrary.IaC.ControlPanel.BusinessLogic.Implementations.Menu
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Menu;

    using Microsoft.EntityFrameworkCore;

    public partial class MenuBusinessLogic
    {
        public async Task<List<Menu>> GetAllAsync()
        {
            using (ControlPanelContext ctx = new ControlPanelContext(_dbContextOptions))
            {
                try
                {
                    return await ctx.Menus.ToListAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new MenuGetAllAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}