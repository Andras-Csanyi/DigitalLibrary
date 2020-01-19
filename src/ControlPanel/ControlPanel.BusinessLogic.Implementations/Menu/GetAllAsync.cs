using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DigitalLibrary.ControlPanel.BusinessLogic.Exceptions.Menu;

using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Menu
{
    using Ctx;
    using Ctx.Ctx;

    public partial class MenuBusinessLogic
    {
        public async Task<List<DomainModel.Entities.Menu>> GetAllAsync()
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