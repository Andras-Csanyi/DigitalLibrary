namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Company
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Ctx.Context;

    using DomainModel.Entities;

    using Exceptions.Exceptions.Company;

    using Microsoft.EntityFrameworkCore;

    public partial class CompanyBusinessLogic
    {
        public async Task<List<Company>> GetAllAsync()
        {
            using (TeamManagerContext ctx = new TeamManagerContext(_dbContextOptions))
            {
                try
                {
                    return await ctx.Companies.ToListAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    throw new CompanyGetAllAsyncOperationException(e.Message, e);
                }
            }
        }
    }
}