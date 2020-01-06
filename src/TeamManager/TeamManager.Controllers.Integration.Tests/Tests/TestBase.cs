namespace TeamManager.Controllers.Integration.Tests.Tests
{
    using DigitalLibrary.IaC.TeamManager.BusinessLogic.Implementations.Implementations.Company;
    using DigitalLibrary.IaC.TeamManager.BusinessLogic.Interfaces.Interfaces;
    using DigitalLibrary.IaC.TeamManager.Ctx.Context;
    using DigitalLibrary.IaC.TeamManager.Validators.Validators;

    using Microsoft.EntityFrameworkCore;

    public class TestBase
    {
        protected readonly DigitalLibrary.IaC.TeamManager.Controllers.Controllers.CompanyController _companyController;

        public TestBase()
        {
            DbContextOptions<TeamManagerContext> options = new DbContextOptionsBuilder<TeamManagerContext>()
                .UseSqlite("Data Source=test.db")
                .Options;
            CompanyValidator companyValidator = new CompanyValidator();
            ICompanyBusinessLogic companyBusinessLogic = new CompanyBusinessLogic(options, companyValidator);
            _companyController =
                new DigitalLibrary.IaC.TeamManager.Controllers.Controllers.CompanyController(companyBusinessLogic);
        }
    }
}