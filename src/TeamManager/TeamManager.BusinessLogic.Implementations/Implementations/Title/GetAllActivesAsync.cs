namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Title
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Title;

    using Microsoft.EntityFrameworkCore;

    public partial class TitleBusinessLogic
    {
        public async Task<List<Title>> GetAllActivesAsync()
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    return await ctx.Titles.Where(p => p.IsActive == 1).ToListAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new TitleGetAllActiveAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}