namespace DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Company
{
    using System;

    using Ctx.Context;

    using Interfaces.Interfaces;

    using Microsoft.EntityFrameworkCore;

    using Validators.Validators;

    public partial class CompanyBusinessLogic : ICompanyBusinessLogic
    {
        private readonly CompanyValidator _companyValidator;

        private readonly DbContextOptions<TeamManagerContext> _dbContextOptions;


        public CompanyBusinessLogic(
            DbContextOptions<TeamManagerContext> dbContextOptions,
            CompanyValidator companyValidator)
        {
            _companyValidator = companyValidator ?? throw new ArgumentNullException(nameof(companyValidator));
            _dbContextOptions = dbContextOptions ?? throw new ArgumentNullException(nameof(dbContextOptions));
        }
    }
}