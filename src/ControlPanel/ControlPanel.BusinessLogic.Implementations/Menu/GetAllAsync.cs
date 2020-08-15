// <copyright file="GetAllAsync.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.BusinessLogic.Implementations.Menu
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Ctx.Ctx;

    using Exceptions.Menu;

    using Microsoft.EntityFrameworkCore;

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